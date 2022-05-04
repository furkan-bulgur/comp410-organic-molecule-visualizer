using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule 
{
    protected GameObject _molecule;
    protected List<Structure> structures = new List<Structure>();
    public Vector3 Position
    {
        get { return _molecule.transform.position; }
        set { _molecule.transform.position = value; }
    }
    public Quaternion Rotation
    {
        get { return _molecule.transform.rotation; }
        set { _molecule.transform.rotation = value.normalized; }
    }
    public void Add(Structure structure)
    {
        structure.ParentStructureTransform = _molecule.transform;
        structures.Add(structure);
    }
    public Molecule()
    {
        _molecule = new GameObject("Molecule");
    }

    protected void BindStructures(Structure mainStructure, Structure sideStructure, int mainStructureBondNum, int sideStructureBondNum)
    {
        if (!mainStructure.IsBondBinded(mainStructureBondNum))
        {
            mainStructure.BindBond(mainStructureBondNum);
        }
        if (!sideStructure.IsBondBinded(sideStructureBondNum))
        {
            sideStructure.BindBond(sideStructureBondNum);
        }
        Vector3 mainDirectionVector = mainStructure.GetBondDirection(mainStructureBondNum);
        Vector3 sideDirectionVector = -1 * mainDirectionVector;
        sideStructure.AlignBondWithDirection(sideDirectionVector, sideStructureBondNum);
        sideStructure.Position = mainStructure.Position;
        sideStructure.Position += mainDirectionVector.normalized * (2*AppConstants.BondLengthOutsideAtom + mainStructure.Atom.Radius + sideStructure.Atom.Radius);
        mainStructure.BindStructure(sideStructure, mainStructureBondNum);
        sideStructure.BindStructure(mainStructure, sideStructureBondNum);
    }

}
