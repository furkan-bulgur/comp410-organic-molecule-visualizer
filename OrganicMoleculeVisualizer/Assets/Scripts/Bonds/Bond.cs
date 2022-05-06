using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bond 
{
    /*
     * Bond:
     * 
     * It is an object mainly to show bonds. When there is a bond between two atoms.
     * There is a two cylinder between them. One for one atom and other for other atom.
     * Bonds material are the same with the material to which bond binded.
     * 
     * Position:
     * Relative to its parent which is a Structure
     * 
     * Scale is default and all bonds have same scale
     * 
     * Rotation is a quaternion and it is not directly accesed
     * 
     * Direction:
     * 
     * Direction is a unit vector representing where bond is directed to. 
     * When it set it changes also the bond's rotation so that bond is aligned with 
     * the direction.
     * Directions are default and not changes during runtime. The default directions are 
     * in the AppConstants and determined by the structures type.   
     * 
     * 
     */
    private GameObject _cylinder;
    private Vector3 _direction;

    public Vector3 Direction
    {
        get { return _direction; }
        set
        {
            _direction = value.normalized;
            Rotation = Quaternion.FromToRotation(AppConstants.DefaultUpVector, _direction);
        }

    }
    public Vector3 Position
    {
        get { return _cylinder.transform.position; }
        set { _cylinder.transform.position = value; }
    }
    public Vector3 Scale
    {
        get { return _cylinder.transform.localScale; }
        set { _cylinder.transform.localScale = value; }
    }

    protected Quaternion Rotation
    {
        get { return _cylinder.transform.rotation; }
        set { _cylinder.transform.rotation = value; }
    }

    public Material Material
    {
        get { return _cylinder.GetComponent<Renderer>().material; }
        set { _cylinder.GetComponent<Renderer>().material = value; }
    }

    public Transform ParentStructureTransform
    {
        get { return _cylinder.transform.parent; }
        set { _cylinder.transform.parent = value; }
    }

    private Bond()
    {
        _cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Direction = AppConstants.DefaultBondDirection;
    }

    public Bond(Vector3 scale) : this()
    {
        Scale = scale;
        
    }

    public Bond(Vector3 position, Vector3 direction, Vector3 scale) : this(scale)
    {
        Position = position;
        Direction = direction;
    }

    public Bond(Atom atom, Vector3 direction, Vector3 scale) : this(scale)
    {
        SetBondAccordingToAtom(atom, direction);

    }

    public void SetBondAccordingToAtom(Atom atom, Vector3 direction)
    {
        // Bonds position needs to be set according to atoms position and its radius.

        Direction = atom.Rotation * direction; //Setting direction and normalizing direction
        // Setting position..
        // Position equals to atoms position plus adding BondLength/2 and BondLengthInsideAtom and atom radius
        // in the direction. 
        Position = atom.Position + Direction * (AppConstants.BondLength / 2 + atom.Radius - AppConstants.BondLengthInsideAtom);
        
        
    }


}
