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
    private BondFactory bondFactory;
    // Start is called before the first frame update
    public NameParser(AtomFactory atomFactory)
    {
        this.atomFactory = atomFactory;
        this.bondFactory = new BondFactory();
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
        else if (name.Equals(HydrogenMolecule))
        {
            new HydrogenMolecule();
            return "Hydrogen Molecule";
        }
        else if (name.Equals("test"))
        {
            new CHMol();
            return "CH";
        }
        return "Invalid Name";
    }
}
