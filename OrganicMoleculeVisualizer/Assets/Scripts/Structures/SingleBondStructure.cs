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
    public override void BindBond(Bond bond)
    {
        if(bond is SingleBond)
        {
            _singleBond = (SingleBond)bond;
        }
        else
        {
            Debug.LogError("Bond is not a Single Bond");
            return;
        }
        _singleBond.SetBondAccordingToAtom(this.Atom, AppConstants.DefaultBondDirection);
        _singleBond.ParentStructureTransform = _structure.transform;
    }

}
