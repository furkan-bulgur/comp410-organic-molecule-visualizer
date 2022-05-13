using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule 
{
    protected GameObject _molecule;

    public MoleculeNode mainNode;
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
    public Transform MoleculeTransform
    {
        get { return _molecule.transform; }
    }


    protected Molecule()
    {
        _molecule = new GameObject("Molecule");
    }

    public Molecule(Structure rootStructure)
    {
        _molecule = new GameObject("Molecule");
        mainNode = new MoleculeNode(rootStructure);
        mainNode.NodeStructure.ParentStructureTransform = MoleculeTransform;
    }

    

}
