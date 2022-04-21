using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomFactory : MonoBehaviour
{
    [SerializeField] public Material carbonMaterial;
    [SerializeField] public Material hydrogenMaterial;

    public Atom createCarbonAtom()
    {
        CarbonAtom carbon = new CarbonAtom();
        carbon.setMaterial(carbonMaterial);
        return carbon;
    }

    public Atom createCarbonAtom(Vector3 initPosition)
    {
        CarbonAtom carbon = new CarbonAtom(initPosition);
        carbon.setMaterial(carbonMaterial);
        return carbon;
    }

    public Atom createHydrogenAtom()
    {
        HydrogenAtom hydrogen = new HydrogenAtom();
        hydrogen.setMaterial(hydrogenMaterial);
        return hydrogen;
    }

    public Atom createHydrogenAtom(Vector3 initPosition)
    {
        HydrogenAtom hydrogen = new HydrogenAtom(initPosition);
        hydrogen.setMaterial(hydrogenMaterial);
        return hydrogen;
    }
}
