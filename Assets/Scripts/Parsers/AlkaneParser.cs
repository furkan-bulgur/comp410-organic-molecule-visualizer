using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
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
        try
        {
            name = Regex.Replace(name.ToLower(), @"\s", "");
            foreach (string mainChainName in AppConstants.AlkaneNaming.Keys)
            {
                if (name.EndsWith(mainChainName))
                {
                    int mainBranchCarbonNum = AppConstants.AlkaneNaming[mainChainName];
                    Dictionary<int, int> branches = new Dictionary<int, int>();
                    var prename = Regex.Replace(name.Replace(mainChainName, ""), @"\s", "");
                    if (prename != "")
                    {
                        string[] splitedPrename = prename.Split("-");
                        if (AppConstants.AlkaneBranchNaming.ContainsKey(splitedPrename[1]))
                        {
                            branches[int.Parse(splitedPrename[0])] = AppConstants.AlkaneBranchNaming[splitedPrename[1]];
                        }
                    }
                    _nameParser.setName(name);
                    return new Alkane(mainBranchCarbonNum, branches);
                }
            }
            throw new Exception();

        }
        catch(Exception e)
        {
            _nameParser.setName("Invalid Name");
            return null;
        }
    }
  
}
