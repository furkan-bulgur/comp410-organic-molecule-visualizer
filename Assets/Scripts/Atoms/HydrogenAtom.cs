using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenAtom : Atom
{
    /*
     * HydrogenAtom
     * 
     * It is a pure Atom with only scale is set to HydrogenAtomScale
     * 
     */
    public HydrogenAtom() : base(AppConstants.HydrogenAtomScale)
    {
        Name = "Hydrogen";
    }
}
