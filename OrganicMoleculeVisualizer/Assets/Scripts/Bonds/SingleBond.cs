using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBond : Bond
{
    public SingleBond() : base(AppConstants.SingleBondScale) { }
    public SingleBond(Atom atom, Vector3 direction) : base(atom, direction, AppConstants.SingleBondScale)
    {

    }
}
