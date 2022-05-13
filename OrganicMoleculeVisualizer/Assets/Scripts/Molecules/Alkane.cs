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

        rootTreeNode = new MoleculeNode(structureFactory.CreateTetrahedralStructure<CarbonAtom>());
        rootTreeNode.NodeStructure.ParentStructureTransform = MoleculeTransform;
        CreateChainAlkane(carbonNumber);
    }


    public void CreateChainAlkane(int carbonNum)
    {
        if (carbonNum > AppConstants.AllowedAlkaneChainMaxCarbonNum)
        {
            throw new System.Exception("Allowed Alkane Chain Num Exceeded");
        }
        MoleculeNode currentNode = rootTreeNode;
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
        //if(_carbonNumber == 2)
        //{
        //    foreach(MoleculeNode child in rootTreeNode.GetAllAdjacent())
        //    {
        //        if (child.IsAtomNode<CarbonAtom>())
        //        {
        //            RotationAroundAxis rax = ConformationUtil.StaggerRotation(rootTreeNode, child);
        //            child.RotateWithChildren(rax);

        //        }
        //    }
        //}
    }

}
