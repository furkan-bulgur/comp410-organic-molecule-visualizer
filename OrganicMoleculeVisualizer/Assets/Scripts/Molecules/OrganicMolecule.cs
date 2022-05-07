using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicMolecule : Molecule
{

    protected List<Structure> carbonStructures = new List<Structure>();
    public List<Structure> CarbonStructures
    {
        get { return carbonStructures; }
    }
    protected List<Structure> hydrogenStructures = new List<Structure>();

    public OrganicMolecule() : base() { }

    public void PopulateWithHydrogen()
    {
        StructureFactory structureFactory = new StructureFactory();
        AtomFactory atomFactory = GameObject.Find("AtomFactory").GetComponent<AtomFactory>();

        foreach (Structure carbonStructure in carbonStructures)
        {
            for(int i = 1; i < carbonStructure.totalBondNum + 1; i++)
            {
                if (!carbonStructure.IsBondBinded(i))
                {
                    Structure hydrogen = structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom());
                    BindStructures(carbonStructure, hydrogen, i, 1);
                    AddHydrogen(hydrogen);
                }
            }
        }
    }
    public void AddCarbon(Structure structure)
    {
        structure.ParentStructureTransform = _molecule.transform;
        carbonStructures.Add(structure);
        allStructures.Add(structure);
    }
    public void AddHydrogen(Structure structure)
    {
        structure.ParentStructureTransform = _molecule.transform;
        hydrogenStructures.Add(structure);
        allStructures.Add(structure);
    }
}
