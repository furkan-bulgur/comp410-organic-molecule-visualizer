using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure
{
    protected GameObject _structure;
    private Atom _atom;
    public Atom Atom
    {
        get { return _atom; }
    }
    public Vector3 Position
    {
        get { return _structure.transform.position; }
        set { _structure.transform.position = value; }
    }
    public Quaternion Rotation
    {
        get { return _structure.transform.rotation; }
        set { _structure.transform.rotation = value.normalized; }
    }

    public Structure(Atom atom)
    {
        _structure = new GameObject("Structure");
        _atom = atom;
        _atom.ParentStructureTransform = _structure.transform;
        //Rotation = AppConstants.DefaultRotation;
       
    }

    public Structure(Atom atom, Quaternion rotation) : this(atom)
    {
        Rotation = rotation;
    }

    public Structure(Atom atom, Quaternion rotation, Vector3 position) : this(atom, rotation)
    {
        Position = position;
    }

    public abstract void BindBond(Bond bond);
}
