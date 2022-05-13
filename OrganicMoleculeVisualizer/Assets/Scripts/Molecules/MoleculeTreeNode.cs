using System.Collections.Generic;
using UnityEngine;

public class MoleculeNode
{
    private Structure _nodeStructure;
    public Structure NodeStructure
    {
        get { return _nodeStructure; }
    }
    
    private Dictionary<int,MoleculeNode> _adjacentStructures = new Dictionary<int, MoleculeNode>();

    public void AddAdjecent(int bond, MoleculeNode node)
    {
        _adjacentStructures[bond] = node;
    }

    public MoleculeNode(Structure nodeStructure)
    {
        _nodeStructure = nodeStructure;
        
    }
    public MoleculeNode(Structure nodeStructure, MoleculeNode mainNode, int mainToNodeBond, int nodeToMainBond)
    {
        _nodeStructure = nodeStructure;
        mainNode.BindNode(this, mainToNodeBond, nodeToMainBond);

    }

    public bool HasAdjecentNode()
    {
        return _adjacentStructures.Count != 0;
    }

    public bool IsAtomNode<A>() where A : Atom
    {
        return NodeStructure.Atom is A;
    }

    public MoleculeNode GetAdjacent(int i)
    {
        if (_adjacentStructures.ContainsKey(i))
        {
            return _adjacentStructures[i];
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    public List<MoleculeNode> GetAllAdjacent()
    {
        List<MoleculeNode> adjs = new List<MoleculeNode>();
        foreach(MoleculeNode node in _adjacentStructures.Values)
        {
            adjs.Add(node);
        }
        return adjs;
    }

    public List<MoleculeNode> GetAllAdjacentWithout(int i)
    {
        List<MoleculeNode> adjs = new List<MoleculeNode>();
        foreach (int bond in _adjacentStructures.Keys)
        {
            if(bond != i)
            {
                adjs.Add(_adjacentStructures[bond]);
            }
            
        }
        return adjs;
    }

    public List<int> GetUnbindedBondNums()
    {
        List<int> nums = new List<int>();
        for(int i = 1; i <= NodeStructure.totalBondNum; i++)
        {
            if(!_adjacentStructures.ContainsKey(i))
            {
                nums.Add(i);
            }
        }
        return nums;
    }

    public List<MoleculeNode> GetAllNodesWithAtom<A>() where A : Atom
    {
        List<MoleculeNode> nodes = new List<MoleculeNode>();
        Stack<MoleculeNode> visit = new Stack<MoleculeNode>();
        List<MoleculeNode> visited = new List<MoleculeNode>();
        visit.Push(this);
        while(visit.Count > 0)
        {
            MoleculeNode current = visit.Pop();
            visited.Add(current);
            if (current.IsAtomNode<A>()) nodes.Add(current);
            foreach (MoleculeNode adj in current.GetAllAdjacent())
            {
                if(!visited.Contains(adj)) visit.Push(adj);
            }
            
        }
        return nodes;
    }

    public List<MoleculeNode> GetAllNodes() 
    {
        Stack<MoleculeNode> visit = new Stack<MoleculeNode>();
        List<MoleculeNode> visited = new List<MoleculeNode>();
        visit.Push(this);
        while (visit.Count > 0)
        {
            MoleculeNode current = visit.Pop();
            visited.Add(current);
            foreach (MoleculeNode adj in current.GetAllAdjacent())
            {
                if (!visited.Contains(adj)) visit.Push(adj);
            }
        }
        return visited;
    }

    public void BindNode(MoleculeNode adjNode, int thisToAdjBond, int adjToThisBond) 
    {
        
        _adjacentStructures[thisToAdjBond] = adjNode;
        adjNode.AddAdjecent(adjToThisBond, this);
        Structure mainStructure = NodeStructure;
        Structure sideStructure = adjNode.NodeStructure;
        sideStructure.ParentStructureTransform = mainStructure.ParentStructureTransform;

        if (!mainStructure.IsBondBinded(thisToAdjBond))
        {
            mainStructure.BindBond(thisToAdjBond);
        }
        if (!sideStructure.IsBondBinded(adjToThisBond))
        {
            sideStructure.BindBond(adjToThisBond);
        }
        Vector3 mainDirectionVector = mainStructure.GetBondDirection(thisToAdjBond);
        Vector3 sideDirectionVector = -1 * mainDirectionVector;
        sideStructure.AlignBondWithDirection(sideDirectionVector, adjToThisBond);
        sideStructure.Position = mainStructure.Position;
        sideStructure.Position += mainDirectionVector.normalized * (2 * AppConstants.BondLengthOutsideAtom + mainStructure.Atom.Radius + sideStructure.Atom.Radius);

    }

    public void RotateWithChildren(RotationAroundAxis rax)
    {
        rax.RotateTransform(NodeStructure.Transform);
        foreach(MoleculeNode child in GetAllAdjacent())
        {
            child.RotateWithChildren(rax);
        }
    }


}
