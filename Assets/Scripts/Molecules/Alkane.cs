using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alkane : OrganicMolecule
{
    private int conformationCalcDepth = 0;
    private StructureFactory structureFactory = new StructureFactory();
    int _carbonNumber;
    public Alkane(int carbonNumber, Dictionary<int,List<int>> branches = null) : base()
    {
        _carbonNumber = carbonNumber;

        //mainNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
        //mainNode.NodeStructure.ParentStructureTransform = MoleculeTransform;
        Dictionary<int,MoleculeNode> mainChainDict = CreateChainAlkane(carbonNumber, MoleculeTransform);
        if(branches != null)
        {
            foreach(int key in branches.Keys)
            {
                foreach(int num in branches[key])
                {
                    CreateBranchAlkane(num, mainChainDict[key], MoleculeTransform);
                }
                
            }
        }
        mainNode = mainChainDict[1];
        PopulateWithHydrogen();
        ArrangeConformations(mainNode);
    }


    public Dictionary<int, MoleculeNode> CreateChainAlkane(int carbonNum, Transform parentStructureTransform)
    {
        Dictionary<int, MoleculeNode> result = new Dictionary<int, MoleculeNode>();
        int counter = 1;
        MoleculeNode firstNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
        firstNode.NodeStructure.ParentStructureTransform = parentStructureTransform;
        result[counter] = firstNode;

        MoleculeNode currentNode = firstNode;
        while(carbonNum > 1)
        {
            MoleculeNode adjNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
            currentNode.BindNode(adjNode, 2, 1);
            counter++;
            result[counter] = adjNode;
            currentNode = adjNode;
            carbonNum--;
        }

        return result;       

    }

    public Dictionary<int, MoleculeNode> CreateBranchAlkane(int carbonNum, MoleculeNode mainNode, Transform parentStructureTransform)
    {
        Dictionary<int, MoleculeNode> result = new Dictionary<int, MoleculeNode>();
        int counter = 1;
        MoleculeNode firstNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
        firstNode.NodeStructure.ParentStructureTransform = parentStructureTransform;
        mainNode.BindNodeToEmpty(firstNode, 1);
        result[counter] = firstNode;

        MoleculeNode currentNode = firstNode;
        while (carbonNum > 1)
        {
            MoleculeNode adjNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
            currentNode.BindNode(adjNode, 2, 1);
            counter++;
            result[counter] = adjNode;
            currentNode = adjNode;
            carbonNum--;
        }

        return result;

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
                Debug.Log(node.NodeStructure.Name + " " + adj.NodeStructure.Name + " " + rax.ToString());
                adj.RotateWithChildren(rax, bondList[1]);
                ArrangeConformations(adj, bondList[1]);
            }
                
        }
        
    }

}
