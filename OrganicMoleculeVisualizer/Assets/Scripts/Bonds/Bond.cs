using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bond 
{
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
        Direction = direction; //Before because it needs to be normalized
        Position = atom.Position + Direction * (AppConstants.BondLength / 2 + atom.Radius - AppConstants.BondLengthInsideAtom);
        
        
    }


}
