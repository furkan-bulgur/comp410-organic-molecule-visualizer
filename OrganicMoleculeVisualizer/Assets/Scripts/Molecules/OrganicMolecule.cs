using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicMolecule : Molecule
{
    StructureFactory structureFactory = new StructureFactory();
    protected OrganicMolecule() : base()
    {
        
    }
    public OrganicMolecule(Structure rootStructure) : base(rootStructure) { }

    public void PopulateWithHydrogen()
    {
        List<MoleculeNode> carbonNodes = rootTreeNode.GetAllNodesWithAtom<CarbonAtom>();
        foreach(MoleculeNode carbonNode in carbonNodes)
        {
            foreach(int num in carbonNode.GetUnbindedBondNums())
            {
                carbonNode.BindNode(new MoleculeNode(structureFactory.CreateSingleBondStructure<HydrogenAtom>()), num, 1);
            }
        }

    }
    
}
