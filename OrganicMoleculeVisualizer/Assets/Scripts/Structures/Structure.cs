using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure
{
    protected GameObject _structure;
    private Atom _atom;
    protected Dictionary<Bond, Structure> bindings = new Dictionary<Bond, Structure>();
    protected Dictionary<int, Bond> bonds = new Dictionary<int, Bond>();
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

    public Transform ParentStructureTransform
    {
        get { return _structure.transform.parent; }
        set { _structure.transform.parent = value; }
    }

    public Structure(Atom atom)
    {
        _structure = new GameObject("Structure");
        _atom = atom;
        _atom.ParentStructureTransform = _structure.transform;
        //Rotation = AppConstants.DefaultRotation;
       
    }
    public Structure(Atom atom, Vector3 position) : this(atom)
    {
        Position = position;
    }

    public Structure(Atom atom, Quaternion rotation) : this(atom)
    {
        Rotation = rotation;
    }

    public Structure(Atom atom, Quaternion rotation, Vector3 position) : this(atom, rotation)
    {
        Position = position;
    }

    public abstract void BindStructure(Structure structure, int bondNum);
    public abstract void BindBond(int bondNum);
    public bool IsBondBinded(int bondNum)
    {
        return bonds.ContainsKey(bondNum);
    }

    public Vector3 GetBondDirection(int bondNum)
    {
        Bond bond = bonds[bondNum];
        Vector3 actualDirectionVector = Rotation * bond.Direction;
        return actualDirectionVector;
    }
    public void AlignBondWithDirection(Vector3 direction, int bondNum)
    {
        Vector3 initialDirection = GetBondDirection(bondNum);
        Quaternion neededRotation = Quaternion.FromToRotation(initialDirection, direction);
        Rotation *= neededRotation;
    }
}
