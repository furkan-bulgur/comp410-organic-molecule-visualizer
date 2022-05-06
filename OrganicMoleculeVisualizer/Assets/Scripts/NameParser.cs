using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;



public class NameParser
{
    private const string CarbonAtom = "carbon";
    private const string HydrogenAtom = "hydrogen";
    private const string HydrogenMolecule = "hydrogenmolecule";

    private AtomFactory atomFactory;
    private BondFactory bondFactory = new BondFactory();
    // Start is called before the first frame update
    public NameParser(AtomFactory atomFactory)
    {
        this.atomFactory = atomFactory;
    }

    public string parseAndCreate(string name)
    {
        name = Regex.Replace(name.ToLower(), @"\s", "");
        Debug.Log(name);
        if (name.Equals(CarbonAtom))
        {
            atomFactory.CreateCarbonAtom();
            return "Carbon";

        }
        else if (name.Equals(HydrogenAtom))
        {
            atomFactory.CreateHydrogenAtom();
            return "Hydrogen";
        }
        else if (name.Equals("methane"))
        {
            new Alkane(1);
            return "Methane";
        }
        else if (name.Equals("test"))
        {
            new Alkane(5);
            return "Ethane";
        }
        return "Invalid Name";
    }
}
