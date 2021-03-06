using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBondStructure : Structure
{
    
    public SingleBondStructure(Atom atom) : base(atom)
    {
        totalBondNum = AppConstants.SingleBondTotalBondNum;
    }
    public override void BindBond(int bondNum)
    {
        BondFactory bondFactory = new BondFactory();
        Bond bond = bondFactory.CreateSingleBondWithName(this.Atom, AppConstants.SingleBondDefaultDirections[bondNum], bondNum);
        bond.ParentStructureTransform = _structure.transform;
        bonds[bondNum] = bond;
    }
    
    

}
