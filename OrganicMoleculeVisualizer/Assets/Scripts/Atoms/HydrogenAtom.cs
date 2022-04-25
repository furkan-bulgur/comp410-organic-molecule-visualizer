using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenAtom : Atom
{
    public HydrogenAtom() : base(AppConstants.HydrogenAtomScale)
    {
    }

    public HydrogenAtom(Vector3 position) : base(position, AppConstants.HydrogenAtomScale)
    {

    }
}
