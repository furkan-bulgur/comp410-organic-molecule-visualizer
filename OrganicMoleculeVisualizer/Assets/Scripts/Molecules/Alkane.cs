using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alkane : OrganicMolecule
{
    int _carbonNumber;
    public Alkane(int carbonNumber) : base()
    {
        _carbonNumber = carbonNumber;
        if(_carbonNumber == 1)
        {
            Methane();
        }
    }
    public void Methane()
    {
        StructureFactory structureFactory = new StructureFactory();
        AtomFactory atomFactory = GameObject.Find("AtomFactory").GetComponent<AtomFactory>();

        Structure carbon = structureFactory.CreateTetrahedralStructure(atomFactory.CreateCarbonAtom());
        Structure hydrogen1 = structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom());
        Structure hydrogen2 = structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom());
        Structure hydrogen3 = structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom());
        Structure hydrogen4 = structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom());
        BindStructures(carbon, hydrogen1, 1, 1);
        BindStructures(carbon, hydrogen2, 2, 1);
        BindStructures(carbon, hydrogen3, 3, 1);
        BindStructures(carbon, hydrogen4, 4, 1);
        Add(carbon);
        Add(hydrogen1);
        Add(hydrogen2);
        Add(hydrogen3);
        Add(hydrogen4);

    }

}
