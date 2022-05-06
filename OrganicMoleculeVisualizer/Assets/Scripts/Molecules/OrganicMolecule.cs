using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicMolecule : Molecule
{
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
}
