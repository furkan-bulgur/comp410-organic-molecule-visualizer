using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBondStructure : Structure
{
    
    public SingleBondStructure(Atom atom) : base(atom)
    {
 
    }
    public override void BindBond(int bondNum)
    {
        BondFactory bondFactory = new BondFactory();
        Bond bond = bondFactory.CreateSingleBond(this.Atom, AppConstants.SingleBondDefaultDirections[bondNum]);
        bond.ParentStructureTransform = _structure.transform;
        bonds[bondNum] = bond;
    }
    
    

}
