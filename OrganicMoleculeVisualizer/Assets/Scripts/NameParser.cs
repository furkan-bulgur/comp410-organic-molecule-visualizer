using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NameParser
{
    private const string CarbonAtom = "carbon";
    private const string HydrogenAtom = "hydrogen";

    private AtomFactory atomFactory;
    // Start is called before the first frame update
    public NameParser(AtomFactory atomFactory)
    {
        this.atomFactory = atomFactory;
    }

    public string parseAndCreate(string name)
    {
        name = name.Trim().ToLower();
        if (name.Equals(CarbonAtom))
        {
            atomFactory.createCarbonAtom();
            return "Carbon";

        }
        else if (name.Equals(HydrogenAtom))
        {
            atomFactory.createHydrogenAtom(new Vector3(1, 1, 0));
            return "Hydrogen";
        }
        return "Invalid Name";
    }
}
