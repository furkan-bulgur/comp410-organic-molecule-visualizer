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
                    Dictionary<int, List<int>> branches = new Dictionary<int, List<int>>();
                    var prename = Regex.Replace(name.Replace(mainChainName, ""), @"\s", "");
                    if (prename != "")
                    {
                        string[] splitedPrename = prename.Split('-');
                        if(splitedPrename.Length%2 == 0)
                        {
                            for(int i = 0;i<splitedPrename.Length; i += 2)
                            {
                                bool containsCountName = false;
                                foreach(string countName in AppConstants.AlkaneBranchCountNaming.Keys)
                                {
                                    if (splitedPrename[i + 1].Contains(countName))
                                    {
                                        Debug.Log("Contains di");
                                        containsCountName = true;
                                        int branchCount = AppConstants.AlkaneBranchCountNaming[countName];
                                        var branchName = Regex.Replace(splitedPrename[i + 1].Replace(countName, ""), @"\s", "");
                                        Debug.Log("Branch name: " + branchName);
                                        if (AppConstants.AlkaneBranchNaming.ContainsKey(branchName))
                                        {
                                            Debug.Log("Contains branch name: " + branchName);
                                            string[] splitedBranchCounts = splitedPrename[i].Split(',');
                                            if(splitedBranchCounts.Length == branchCount)
                                            {
                                                for(int j=0; j<branchCount; j++)
                                                {
                                                    if (branches.ContainsKey(int.Parse(splitedBranchCounts[j])))
                                                    {
                                                        branches[int.Parse(splitedBranchCounts[j])].Add(AppConstants.AlkaneBranchNaming[branchName]);
                                                    }
                                                    else
                                                    {
                                                        branches[int.Parse(splitedBranchCounts[j])] = new List<int> { AppConstants.AlkaneBranchNaming[branchName] };
                                                    }
                                                    
                                                }
                                            }
                                            
                                        }
                                    }
                                    
                                }
                                if (!containsCountName)
                                {
                                    if (AppConstants.AlkaneBranchNaming.ContainsKey(splitedPrename[i+1]))
                                    {
                                        if (branches.ContainsKey(int.Parse(splitedPrename[i])))
                                        {
                                            branches[int.Parse(splitedPrename[i])].Add(AppConstants.AlkaneBranchNaming[splitedPrename[i + 1]]);
                                        }
                                        else
                                        {
                                            branches[int.Parse(splitedPrename[i])] = new List<int> { AppConstants.AlkaneBranchNaming[splitedPrename[i + 1]] };
                                        }
                                    }
                                }
                                
                            }
                        }
                        
                    }
                    _nameParser.setName(name);
                    foreach(int key in branches.Keys)
                    {
                        Debug.Log("-----------");
                        Debug.Log(key);
                        Debug.Log(branches[key]);
                        Debug.Log("-----------");
                    }
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
