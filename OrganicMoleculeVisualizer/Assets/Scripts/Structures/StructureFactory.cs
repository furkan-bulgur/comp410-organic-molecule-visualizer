using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StructureFactory 
{
    public static Dictionary<System.Type, int> counts = new Dictionary<System.Type, int>
    {
        {typeof(CarbonAtom),0},
        {typeof(HydrogenAtom),0},
    };
    AtomFactory atomFactory = GameObject.Find("AtomFactory").GetComponent<AtomFactory>();

    public Structure CreateSingleBondStructure<A>() where A : Atom
    {
        counts[typeof(A)] += 1;
        Structure structure = new SingleBondStructure(atomFactory.CreateAtom<A>());
        structure.Name = "Single Bond " + structure.Atom.Name + " Structure " + counts[typeof(A)];
        return structure;
    }

    public Structure CreateTetrahedralStructure<A>() where A : Atom
    {
        counts[typeof(A)] += 1;
        Structure structure = new TetrahedralStructure(atomFactory.CreateAtom<A>());
        structure.Name = "Tetrahedral " + structure.Atom.Name + " Structure " + counts[typeof(A)];
        return structure;
    }

    public static void ResetCounts()
    {
        foreach (System.Type type in counts.Keys.ToList())
        {
            counts[type] = 0;
        }
    }
}
