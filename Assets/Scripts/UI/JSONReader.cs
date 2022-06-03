using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        Alkanes_UI alkanesInJson = JsonUtility.FromJson<Alkanes_UI>(jsonFile.text);

        foreach (Alkane_UI alkane in alkanesInJson.alkanes)
        {
            Debug.Log("Found alkane: " + alkane.name + " " + alkane.pubchemCID + " " +  alkane.molecular_formula + " "
                + alkane.molecular_weight  + " " + alkane.explanation);
        }
    }
}
