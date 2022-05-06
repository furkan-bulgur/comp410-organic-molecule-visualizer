using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alkane : OrganicMolecule
{
    int _carbonNumber;
    public Alkane(int carbonNumber) : base()
    {
        _carbonNumber = carbonNumber;
        if (_carbonNumber == 1)
        {
            Methane();
        }
        CreateChainAlkane(carbonNumber);
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
        AddCarbon(carbon);
        AddHydrogen(hydrogen1);
        AddHydrogen(hydrogen2);
        AddHydrogen(hydrogen3);
        AddHydrogen(hydrogen4);

    }

    public void CreateChainAlkane(int carbonNum)
    {
        if(carbonNum > AppConstants.AllowedAlkaneChainMaxCarbonNum)
        {
            throw new System.Exception("Allowed Alkane Chain Num Exceeded");
        }
        StructureFactory structureFactory = new StructureFactory();
        AtomFactory atomFactory = GameObject.Find("AtomFactory").GetComponent<AtomFactory>();

        Structure successorCarbon = null;
        Structure predecessorCarbon = structureFactory.CreateTetrahedralStructure(atomFactory.CreateCarbonAtom());
        while(carbonNum > 1)
        {
            successorCarbon = structureFactory.CreateTetrahedralStructure(atomFactory.CreateCarbonAtom());
            BindStructures(predecessorCarbon, successorCarbon, 1, 2);
            AddCarbon(predecessorCarbon);
            predecessorCarbon = successorCarbon;
            carbonNum -= 1;
        }
        if(successorCarbon != null)
        {
            AddCarbon(successorCarbon);
        }
        PopulateWithHydrogen();
        
    }

}
