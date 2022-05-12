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
        List<MoleculeTreeNode> carbonNodes = rootTreeNode.GetAllNodesWithAtom<CarbonAtom>();
        foreach(MoleculeTreeNode carbonNode in carbonNodes)
        {
            foreach(int num in carbonNode.GetUnbindedBondNums())
            {
                carbonNode.BindChild(new MoleculeTreeNode(structureFactory.CreateSingleBondStructure<HydrogenAtom>()), num, 1);
            }
        }

    }
    
}
