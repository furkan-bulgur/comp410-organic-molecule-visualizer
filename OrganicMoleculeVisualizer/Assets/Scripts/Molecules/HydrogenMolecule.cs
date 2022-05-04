using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenMolecule : InorganicMolecule
{
    public HydrogenMolecule() : base()
    {
        StructureFactory structureFactory = new StructureFactory();
        AtomFactory atomFactory = new AtomFactory();

        structures.Add(structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom()));
        structures[0].ParentStructureTransform = _molecule.transform;
        structures.Add(structureFactory.CreateSingleBondStructure(atomFactory.CreateHydrogenAtom()));
        structures[1].ParentStructureTransform = _molecule.transform;
        BindStructures(structures[0], structures[1], 1, 1);


    }
}
