using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alkane : OrganicMolecule
{
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
        ArrangeConformations();

    }

    public void ArrangeConformations()
    {
        if (_carbonNumber == 2)
        {

            foreach (List<int> bondList in mainNode.Adjecents.Keys)
            {
                MoleculeNode adj = mainNode.Adjecents[bondList];
                if (adj.IsAtomNode<CarbonAtom>())
                {
                    RotationAroundAxis rax = ConformationUtil.StaggerRotation(mainNode, adj, bondList);
                    adj.RotateWithChildren(rax, bondList[1]);
                }
                
            }
        }
    }

    }
