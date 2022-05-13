using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure
{
    protected GameObject _structure;
    private Atom _atom;
    public int totalBondNum;
    protected Dictionary<int, Bond> bonds = new Dictionary<int, Bond>();
    public Atom Atom
    {
        get { return _atom; }
    }
    public Transform Transform
    {
        get { return _structure.transform; }
    }
    public Vector3 Position
    {
        get { return _structure.transform.position; }
        set { _structure.transform.position = value; }
    }
    public Quaternion Rotation
    {
        get { return _structure.transform.rotation; }
        set {
                _structure.transform.rotation = value.normalized;
                Atom.Rotation = _structure.transform.rotation;
                foreach (Bond bond in bonds.Values)
                {
                    bond.Direction = _structure.transform.rotation * bond.Direction;
                }
        }
    }

    public void RotateTransform(Vector3 point, Vector3 axis, float angle)
    {
        Transform.RotateAround(point, axis, angle);
        Quaternion rotation = Quaternion.AngleAxis(angle, axis);
        foreach (Bond bond in bonds.Values)
        {
            bond.Direction = rotation * bond.Direction;
        }

    }

    public Transform ParentStructureTransform
    {
        get { return _structure.transform.parent; }
        set { _structure.transform.parent = value; }
    }

    public string Name
    {
        get { return _structure.name; }
        set { _structure.name = value; }
    }

    public Structure(Atom atom)
    {
        _structure = new GameObject("Structure");
        _atom = atom;
        _atom.ParentStructureTransform = _structure.transform;
        
       
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

    
    public abstract void BindBond(int bondNum);
    //public void BindStructure(Structure structure, int bondNum = AppConstants.SingleBondNum)
    //{
    //    bindings[bondNum] = structure;
    //}
    public bool IsBondBinded(int bondNum)
    {
        return bonds.ContainsKey(bondNum);
    }

    public Vector3 GetBondDirection(int bondNum)
    {
        return bonds[bondNum].Direction;
    }

    public void AlignBondWithDirection(Vector3 direction, int bondNum)
    {
        Vector3 initialDirection = GetBondDirection(bondNum);
        Quaternion neededRotation = Quaternion.FromToRotation(initialDirection, direction);
        Rotation *= neededRotation;
    }
}
