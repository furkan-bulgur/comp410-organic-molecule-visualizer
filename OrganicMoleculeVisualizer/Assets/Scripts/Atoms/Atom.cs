using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Atom 
{
    /*
     * Atom
     * 
     * This is an object representing atoms and their sphere objects.
     * 
     * Position: 
     * Its position is relative to its parent which is a Structure and it is mostly 
     * untouched and 0,0,0
     * 
     * Scale:
     * Scale changes from atom to atom. The default scales for different type of atoms
     * are written in AppConstants
     * 
     * Rotation:
     * Atoms rotation visually represents nothing but it is helpful in understanding the
     * directions of bonds. Atoms rotation is same as its parent structure's rotation and
     * it is set when structure's rotation is set.
     * 
     * Material:
     * Material is set by the AtomFactory and it is different for differnt atom types.
     * 
     * 
     * ParentStructureTransform is for setting and getting its parents which is generally structure.
     * 
     * 
     * 
     */
    private GameObject _sphere;
    public Vector3 Position
    {
        get { return _sphere.transform.position; }
        set { _sphere.transform.position = value; }
    }
    public Vector3 Scale
    {
        get { return _sphere.transform.localScale; }
        set { _sphere.transform.localScale = value; }
    }
    public Quaternion Rotation
    {
        get { return _sphere.transform.rotation; }
        set { _sphere.transform.rotation = value; }
    }
    public Material Material
    {
        get { return _sphere.GetComponent<Renderer>().material; }
        set { _sphere.GetComponent<Renderer>().material = value; }
    }

    public Transform ParentStructureTransform
    {
        get { return _sphere.transform.parent; }
        set { _sphere.transform.parent = value; }
    }

    public float Radius
    {
        // Multiplying with scale to get actual radius because scale is uniform
        // taking one of its values is enough
        get { return Scale.x/2; }
    }

    public Atom()
    {
        _sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    public Atom(Vector3 scale) : this()
    {
        Scale = scale;
    }

}
