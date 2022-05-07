using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AlkaneParser 
{
    private NameParser _nameParser;
    public AlkaneParser(NameParser nameParser)
    {
        _nameParser = nameParser;
    }

    public Molecule parse(string name)
    {
        name = Regex.Replace(name.ToLower(), @"\s", "");
        if (name.Equals("methane"))
        {
            _nameParser.setName("Methane");
            return new Alkane(1);
        }
        else if (name.Equals("ethane"))
        {
            _nameParser.setName("Ethane");
            return new Alkane(2);
        }
        else if (name.Equals("propane"))
        {
            _nameParser.setName("Propane");
            return new Alkane(3);
        }
        else if (name.Equals("butane"))
        {
            _nameParser.setName("Butane");
            return new Alkane(4);
        }
        else if (name.Equals("heptane"))
        {
            _nameParser.setName("Heptane");
            return new Alkane(5);
        }
        else if (name.Equals("hexane"))
        {
            _nameParser.setName("Hexane");
            return new Alkane(6);
        }
        else
        {
            _nameParser.setName("Invalid Name");
            return null;
        }
    }
  
}
