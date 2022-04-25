using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonAtom : Atom
{
    
    public CarbonAtom() : base(AppConstants.CarbonAtomScale)
    {
    }

    public CarbonAtom(Vector3 position) : base(position,AppConstants.CarbonAtomScale)
    {

    }

}
