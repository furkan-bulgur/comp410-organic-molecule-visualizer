using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeTreeNode
{
    private Structure _nodeStructure;
    public Structure NodeStructure
    {
        get { return _nodeStructure; }
    }
    private MoleculeTreeNode _parentNode;
    public MoleculeTreeNode Parent
    {
        get { return _parentNode; }
        set { _parentNode = value; }
    }
    // Node's bond index which connected to parent
    public int ChildToParentBond
    {
        get; set;
    }
    public int ParentToChildBond
    {
        get; set;
    }
    private Dictionary<int,MoleculeTreeNode> _childStructures = new Dictionary<int, MoleculeTreeNode>();


    public MoleculeTreeNode(Structure nodeStructure)
    {
        _nodeStructure = nodeStructure;
        ChildToParentBond = -1;
        _parentNode = null;
        
    }
    public MoleculeTreeNode(Structure nodeStructure, MoleculeTreeNode parentNode, int parentToChildBondIndex, int childToParentBondIndex)
    {
        _nodeStructure = nodeStructure;
        Parent = parentNode;
        Parent.BindChild(this, parentToChildBondIndex, childToParentBondIndex);

    }

    public bool HasChild()
    {
        return _childStructures.Count != 0;
    }

    public bool IsAtomNode<A>() where A : Atom
    {
        return NodeStructure.Atom is A;
    }

    public MoleculeTreeNode GetChild(int i)
    {
        if (_childStructures.ContainsKey(i))
        {
            return _childStructures[i];
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    public List<MoleculeTreeNode> GetChildren()
    {
        List<MoleculeTreeNode> childs = new List<MoleculeTreeNode>();
        foreach(MoleculeTreeNode node in _childStructures.Values)
        {
            childs.Add(node);
        }
        return childs;
    }

    public List<int> GetUnbindedBondNums()
    {
        List<int> nums = new List<int>();
        for(int i = 1; i <= NodeStructure.totalBondNum; i++)
        {
            if(ChildToParentBond != i && !_childStructures.ContainsKey(i))
            {
                nums.Add(i);
            }
        }
        return nums;
    }

    public List<MoleculeTreeNode> GetAllNodesWithAtom<A>() where A : Atom
    {
        List<MoleculeTreeNode> nodes = new List<MoleculeTreeNode>();
        Stack<MoleculeTreeNode> visit = new Stack<MoleculeTreeNode>();
        visit.Push(this);
        while(visit.Count > 0)
        {
            MoleculeTreeNode current = visit.Pop();
            if (current.IsAtomNode<A>()) nodes.Add(current);
            foreach (MoleculeTreeNode child in current.GetChildren())
            {
                visit.Push(child);
            }
        }
        return nodes;
    }

    public List<MoleculeTreeNode> GetAllNodes() 
    {
        List<MoleculeTreeNode> nodes = new List<MoleculeTreeNode>();
        Stack<MoleculeTreeNode> visit = new Stack<MoleculeTreeNode>();
        visit.Push(this);
        while (visit.Count > 0)
        {
            MoleculeTreeNode current = visit.Pop();
            nodes.Add(current);
            foreach (MoleculeTreeNode child in current.GetChildren())
            {
                visit.Push(child);
            }
        }
        return nodes;
    }

    public void BindChild(MoleculeTreeNode child, int parentToChildBondIndex, int childToParentBondIndex) 
    {
        
        _childStructures[parentToChildBondIndex] = child;
        child.ChildToParentBond = childToParentBondIndex;
        child.ParentToChildBond = parentToChildBondIndex;
        Structure mainStructure = NodeStructure;
        Structure sideStructure = child.NodeStructure;
        sideStructure.ParentStructureTransform = mainStructure.ParentStructureTransform;

        if (!mainStructure.IsBondBinded(parentToChildBondIndex))
        {
            mainStructure.BindBond(parentToChildBondIndex);
        }
        if (!sideStructure.IsBondBinded(childToParentBondIndex))
        {
            sideStructure.BindBond(childToParentBondIndex);
        }
        Vector3 mainDirectionVector = mainStructure.GetBondDirection(parentToChildBondIndex);
        Vector3 sideDirectionVector = -1 * mainDirectionVector;
        sideStructure.AlignBondWithDirection(sideDirectionVector, childToParentBondIndex);
        sideStructure.Position = mainStructure.Position;
        sideStructure.Position += mainDirectionVector.normalized * (2 * AppConstants.BondLengthOutsideAtom + mainStructure.Atom.Radius + sideStructure.Atom.Radius);

    }

    public void RotateWithChildren(RotationAroundAxis rax)
    {
        rax.RotateTransform(NodeStructure.Transform);
        foreach(MoleculeTreeNode child in GetChildren())
        {
            child.RotateWithChildren(rax);
        }
    }


}
