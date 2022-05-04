using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrahedralStructure : Structure
{

    public TetrahedralStructure(Atom atom) : base(atom) { }
    public override void BindBond(int bondNum)
    {
        BondFactory bondFactory = new BondFactory();
        Bond bond = bondFactory.CreateSingleBond(this.Atom, AppConstants.TetrahedralBondDefaultDirections[bondNum]);
        bond.ParentStructureTransform = _structure.transform;
        bonds[bondNum] = bond;
    }

    
}
