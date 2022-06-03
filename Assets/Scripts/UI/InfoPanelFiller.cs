using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanelFiller : MonoBehaviour
{
    [SerializeField] public TMP_InputField moleculeInput;
    [SerializeField] public TMP_Text molecule_name;
    [SerializeField] public TMP_Text pubchemCID;
    [SerializeField] public TMP_Text molecular_formula;
    [SerializeField] public TMP_Text molecular_weight;
    [SerializeField] public TMP_Text explantion;
    [SerializeField] public TextAsset jsonFile;

    private string mol_name;
    private Alkane_UI wanted_mol;
    private Alkanes_UI alkanesInJson;
    void Start()
    {
        alkanesInJson = JsonUtility.FromJson<Alkanes_UI>(jsonFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        mol_name = moleculeInput.text.ToLower();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Molecule name: " + mol_name);

            foreach (Alkane_UI alkane in alkanesInJson.alkanes)
            {
                if (alkane.name == mol_name)
                {
                    wanted_mol = alkane;
                }
            }
            Debug.Log("Found alkane: " + wanted_mol.name + " " + wanted_mol.pubchemCID + " " + wanted_mol.molecular_formula + " "
            + wanted_mol.molecular_weight + " " + wanted_mol.explanation);

            molecule_name.text = "Molecule Name: " + wanted_mol.name.ToUpper();
            pubchemCID.text = "PubChem CID: " + wanted_mol.pubchemCID;
            molecular_formula.text = "Molecular Formula: " + wanted_mol.molecular_formula.ToUpper();
            molecular_weight.text = "Molecular Weight: " + wanted_mol.molecular_weight;
            explantion.text = wanted_mol.explanation;
        }
    }
}
