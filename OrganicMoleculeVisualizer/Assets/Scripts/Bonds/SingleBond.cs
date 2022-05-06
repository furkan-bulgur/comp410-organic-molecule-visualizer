using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBond : Bond
{
    /*
     * Single Bond:
     *
     *  It is a bond but showing single bond. Representing single bonds between atoms.
     */
    public SingleBond() : base(AppConstants.SingleBondScale) { }
    public SingleBond(Atom atom, Vector3 direction) : base(atom, direction, AppConstants.SingleBondScale)
    {

    }
}
