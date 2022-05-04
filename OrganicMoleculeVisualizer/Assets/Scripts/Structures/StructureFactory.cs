using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureFactory 
{
    public Structure CreateSingleBondStructure(Atom atom)
    {
        return new SingleBondStructure(atom);
    }
}
