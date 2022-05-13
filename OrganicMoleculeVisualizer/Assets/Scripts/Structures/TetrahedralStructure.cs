using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrahedralStructure : Structure
{

    public TetrahedralStructure(Atom atom) : base(atom)
    {
        totalBondNum = AppConstants.TetrahedralTotalBondNum;
    }
    public override void BindBond(int bondNum)
    {
        BondFactory bondFactory = new BondFactory();
        Bond bond = bondFactory.CreateSingleBondWithName(this.Atom, AppConstants.TetrahedralBondDefaultDirections[bondNum], bondNum);
        bond.ParentStructureTransform = _structure.transform;
        bonds[bondNum] = bond;
    }

    
}
