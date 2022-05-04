using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureFactory 
{
    public Structure CreateSingleBondStructure(Atom atom)
    {
        return new SingleBondStructure(atom);
    }

    public Structure CreateTetrahedralStructure(Atom atom)
    {
        return new TetrahedralStructure(atom);
    }
}
