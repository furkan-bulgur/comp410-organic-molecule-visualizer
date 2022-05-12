using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureFactory 
{
    AtomFactory atomFactory = GameObject.Find("AtomFactory").GetComponent<AtomFactory>();

    public Structure CreateSingleBondStructure<A>() where A : Atom
    {
        return new SingleBondStructure(atomFactory.CreateAtom<A>());
    }

    public Structure CreateTetrahedralStructure<A>() where A : Atom
    {
        return new TetrahedralStructure(atomFactory.CreateAtom<A>());
    }
}
