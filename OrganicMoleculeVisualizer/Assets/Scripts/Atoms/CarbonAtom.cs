using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonAtom : Atom
{
    /*
     * CarbonAtom
     * 
     * It is a pure Atom with only scale is set to CarbonAtomScale
     * 
     */
    public CarbonAtom() : base(AppConstants.CarbonAtomScale)
    {
        Name = "Carbon";
    }

}
