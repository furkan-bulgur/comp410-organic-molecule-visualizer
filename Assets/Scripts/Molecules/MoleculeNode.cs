using System.Collections.Generic;
using UnityEngine;

public class MoleculeNode
{
    private Structure _nodeStructure;
    public Structure NodeStructure
    {
        get { return _nodeStructure; }
    }
    
    private Dictionary<List<int>,MoleculeNode> _adjacentStructures = new Dictionary<List<int>, MoleculeNode>();
    public Dictionary<List<int>, MoleculeNode> Adjecents
    {
        get { return _adjacentStructures; }
    }

    public void AddAdjecent(int bondToAdj, int bondAdjtoThis, MoleculeNode node)
    {
        List<int> bondList = new List<int> { bondToAdj, bondAdjtoThis };
        _adjacentStructures[bondList] = node;
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
        foreach(List<int> bondList in _adjacentStructures.Keys)
        {
            if(bondList[0] == i)
            {
                return _adjacentStructures[bondList];
            }
        }
        return null;
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

    public List<MoleculeNode> GetAllAdjecentWithAtom<A>() where A : Atom
    {
        List<MoleculeNode> adjs = new List<MoleculeNode>();
        foreach (MoleculeNode node in _adjacentStructures.Values)
        {
            if(node.IsAtomNode<A>()) adjs.Add(node);
        }
        return adjs;
    }

    public List<int> GetAllAdjecentBondNumsWithAtomWithout<A>(int i) where A : Atom
    {
        List<int> nums = new List<int>();
        foreach (List<int> bondList in _adjacentStructures.Keys)
        {
            if (_adjacentStructures[bondList].IsAtomNode<A>() && bondList[0] != i)
            {
                nums.Add(bondList[0]);
            }
        }
        return nums;
    }

    public List<MoleculeNode> GetAllAdjacentWithout(int i)
    {
        List<MoleculeNode> adjs = new List<MoleculeNode>();
        foreach (List<int> bondList in _adjacentStructures.Keys)
        {
            if (bondList[0] != i)
            {
                adjs.Add(_adjacentStructures[bondList]);
            }
        }
        return adjs;
    }

    public List<int> GetUnbindedBondNums()
    {
        List<int> bindedBonds = GetBindedBondNums();
        List<int> nums = new List<int>();
        for(int i = 1; i <= NodeStructure.totalBondNum; i++)
        {
            if(!bindedBonds.Contains(i))
            {
                nums.Add(i);
            }
        }
        return nums;
    }

    public List<int> GetBindedBondNums()
    {
        List<int> nums = new List<int>();
        foreach (List<int> bondList in _adjacentStructures.Keys)
        {
            nums.Add(bondList[0]);
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
        AddAdjecent(thisToAdjBond, adjToThisBond, adjNode);
        adjNode.AddAdjecent(adjToThisBond, thisToAdjBond , this);
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

  
    public void RotateWithChildren(RotationAroundAxis rax, int prevBond)
    {
        rax.RotateTransform(this);
        foreach (List<int> bondList in Adjecents.Keys)
        {
            if (bondList[0] != prevBond)
            {
                MoleculeNode adj = Adjecents[bondList];
                adj.RotateWithChildren(rax, bondList[1]);
            }

        }
    }

   


}
