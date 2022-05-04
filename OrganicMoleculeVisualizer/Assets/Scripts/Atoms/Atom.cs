using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Atom 
{
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

    public Atom(Vector3 position, Vector3 scale) : this(scale)
    {
        Position = position;

    }

}
