using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomFactory : MonoBehaviour
{
    [SerializeField] public Material carbonMaterial;
    [SerializeField] public Material hydrogenMaterial;

    public Atom CreateCarbonAtom()
    {
        CarbonAtom carbon = new CarbonAtom();
        carbon.Material = carbonMaterial;
        return carbon;
    }

    public Atom CreateCarbonAtom(Vector3 initPosition)
    {
        CarbonAtom carbon = new CarbonAtom(initPosition);
        carbon.Material = carbonMaterial;
        return carbon;
    }

    public Atom CreateHydrogenAtom()
    {
        HydrogenAtom hydrogen = new HydrogenAtom();
        hydrogen.Material = hydrogenMaterial;
        return hydrogen;
    }

    public Atom CreateHydrogenAtom(Vector3 initPosition)
    {
        HydrogenAtom hydrogen = new HydrogenAtom(initPosition);
        hydrogen.Material = hydrogenMaterial;
        return hydrogen;
    }
}
