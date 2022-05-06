using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomFactory : MonoBehaviour
{
    /*
     * Atom Factory
     * 
     * Creates atoms and sets their material with corresponding material.
     * It is an game object on the scene.
     * 
     */
    [SerializeField] public Material carbonMaterial;
    [SerializeField] public Material hydrogenMaterial;

    public Atom CreateCarbonAtom()
    {
        CarbonAtom carbon = new CarbonAtom();
        carbon.Material = carbonMaterial;
        return carbon;
    }

    public Atom CreateHydrogenAtom()
    {
        HydrogenAtom hydrogen = new HydrogenAtom();
        hydrogen.Material = hydrogenMaterial;
        return hydrogen;
    }

}
