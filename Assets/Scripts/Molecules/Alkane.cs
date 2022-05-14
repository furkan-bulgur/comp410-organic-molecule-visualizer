using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alkane : OrganicMolecule
{
    private int conformationCalcDepth = 0;
    private StructureFactory structureFactory = new StructureFactory();
    int _carbonNumber;
    public Alkane(int carbonNumber) : base()
    {
        _carbonNumber = carbonNumber;

        mainNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
        mainNode.NodeStructure.ParentStructureTransform = MoleculeTransform;
        CreateChainAlkane(carbonNumber);
    }


    public void CreateChainAlkane(int carbonNum)
    {
        if (carbonNum > AppConstants.AllowedAlkaneChainMaxCarbonNum)
        {
            throw new System.Exception("Allowed Alkane Chain Num Exceeded");
        }
        MoleculeNode currentNode = mainNode;
        while(carbonNum > 1)
        {
            MoleculeNode adjNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
            currentNode.BindNode(adjNode, 2, 1);
            currentNode = adjNode;
            carbonNum--;
        }

        PopulateWithHydrogen();
        ArrangeConformations(mainNode);
        //ArrangeConformations(mainNode.GetAdjacent(2),1);
        

    }

    public void ArrangeConformations(MoleculeNode node, int prevBond = -1)
    {
        conformationCalcDepth += 1;
        if(conformationCalcDepth > GameObject.Find("MainObject").GetComponent<Main>().conformationMaxDepth)
        {
            return;
        }
        foreach (List<int> bondList in node.Adjecents.Keys)
        {
            MoleculeNode adj = node.Adjecents[bondList];
            if (adj.IsAtomNode<CarbonAtom>() && bondList[0] != prevBond)
            {
                RotationAroundAxis rax = ConformationUtil.StaggerRotation(node, adj, bondList);
                adj.RotateWithChildren(rax, bondList[1]);
                ArrangeConformations(adj, bondList[1]);
            }
                
        }
        
    }

}
