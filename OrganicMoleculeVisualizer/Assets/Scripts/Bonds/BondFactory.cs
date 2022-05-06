using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BondFactory
{
    /*
     * Bond Factory:
     * 
     * Creates bonds according to their type and atom which they are binded.
     * Sets their material to the atom which they are binded to.
     * 
     */
    public BondFactory() { }
    public SingleBond CreateSingleBond()
    {
        return new SingleBond();
    }
    public SingleBond CreateSingleBond(Atom atom, Vector3 direction)
    {
        SingleBond singleBond = new SingleBond(atom, direction);
        singleBond.Material = atom.Material;
        return singleBond;
    }
}
