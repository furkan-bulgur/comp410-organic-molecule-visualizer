using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NameParser
{
    private const string CarbonAtom = "carbon";
    private const string HydrogenAtom = "hydrogen";

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
        name = name.Trim().ToLower();
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
        else if (name.Equals("test"))
        {
            Atom carbon = atomFactory.CreateCarbonAtom();
            Bond bond = bondFactory.CreateSingleBond();
            SingleBondStructure structure = new SingleBondStructure(carbon);//, Quaternion.Euler(new Vector3(0,0,-90)));
            structure.BindBond(bond);
        }
        return "Invalid Name";
    }
}
