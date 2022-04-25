using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BondFactory
{
    public BondFactory() { }
    public SingleBond CreateSingleBond()
    {
        return new SingleBond();
    }
    public SingleBond CreateSingleBond(Atom atom, Vector3 direction)
    {
        return new SingleBond(atom, direction);
    }
}
