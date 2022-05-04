using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHMol : TestMolecules
{
    public CHMol() : base()
    {
        StructureFactory structureFactory = new StructureFactory();
        AtomFactory atomFactory = GameObject.Find("AtomFactory").GetComponent<AtomFactory>();

        Structure carbon = structureFactory.CreateSingleBondStructure(atomFactory.CreateCarbonAtom());
        Structure hydrogen = structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom());
        BindStructures(carbon, hydrogen, 1, 1);
        Add(carbon);
        Add(hydrogen);

    }
}
