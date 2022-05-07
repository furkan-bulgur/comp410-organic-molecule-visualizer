using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;



public class NameParser
{
    private const string CarbonAtom = "carbon";
    private const string HydrogenAtom = "hydrogen";

    private Main _main;

    private AtomFactory atomFactory;
    // Start is called before the first frame update
    public NameParser(Main main, AtomFactory atomFactory)
    {
        _main = main;
        this.atomFactory = atomFactory;
    }

    public void parseAndCreate(string name)
    {
        _main.destroyPrevMolecule();
        name = Regex.Replace(name.ToLower(), @"\s", "");
        Debug.Log(name);
        Molecule resultMolecule = null;
        if (name.EndsWith("ane"))
        {
            AlkaneParser alkaneParser = new AlkaneParser(this);
            resultMolecule = alkaneParser.parse(name);
        }
        if(resultMolecule != null)
        {
            _main.CurrentMolecule = resultMolecule;
        }
    }

    public void setName(string name)
    {
        _main.setInfoText(name);
    }
}
