using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBondStructure : Structure
{
    private SingleBond _singleBond;
    
    public SingleBondStructure(Atom atom) : base(atom)
    {
 
    }
    public SingleBondStructure(Atom atom, Quaternion rotation) : base(atom, rotation)
    {

    }
    public SingleBondStructure(Atom atom, Quaternion rotation, Vector3 position) : base(atom, rotation, position)
    {

    }
    public override void BindBond(int bondNum)
    {
        BondFactory bondFactory = new BondFactory();
        Bond bond = bondFactory.CreateSingleBond(this.Atom, AppConstants.SingleBondDefaultDirection[bondNum]);
        bond.ParentStructureTransform = _structure.transform;
        bonds[bondNum] = bond;
    }
    public override void BindStructure(Structure structure, int bondNum=AppConstants.SingleBondNum)
    { 
        bindings[bonds[bondNum]] = structure;
    }
    

}
