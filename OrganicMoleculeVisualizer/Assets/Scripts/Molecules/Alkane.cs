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

        rootTreeNode = new MoleculeTreeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
        rootTreeNode.NodeStructure.ParentStructureTransform = MoleculeTransform;
        CreateChainAlkane(carbonNumber);
    }


    public void CreateChainAlkane(int carbonNum)
    {
        if (carbonNum > AppConstants.AllowedAlkaneChainMaxCarbonNum)
        {
            throw new System.Exception("Allowed Alkane Chain Num Exceeded");
        }
        MoleculeTreeNode currentNode = rootTreeNode;
        while(carbonNum > 1)
        {
            MoleculeTreeNode childNode = new MoleculeTreeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
            currentNode.BindChild(childNode, 2, 1);
            currentNode = childNode;
            carbonNum--;
        }

        PopulateWithHydrogen();
        ArrangeConformations();

    }

    public void ArrangeConformations()
    {
        if(_carbonNumber == 2)
        {
            foreach(MoleculeTreeNode child in rootTreeNode.GetChildren())
            {
                if (child.IsAtomNode<CarbonAtom>())
                {
                    RotationAroundAxis rax = ConformationUtil.StaggerRotation(rootTreeNode, child);
                    child.RotateWithChildren(rax);

                }
            }
        }
    }

}
