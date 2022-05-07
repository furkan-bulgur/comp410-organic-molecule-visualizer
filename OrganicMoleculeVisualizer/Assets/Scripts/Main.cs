using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] public InputField nameInput;
    [SerializeField] public Text infoText;
    [SerializeField] public AtomFactory atomFactory;
    [SerializeField] public GameObject temp;

    private Molecule _currentMolecule;
    public Molecule CurrentMolecule
    {
        get { return _currentMolecule; }
        set { _currentMolecule = value; }
    }

    private NameParser nameParser;
    void Start()
    {
        nameParser = new NameParser(this,atomFactory); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            nameParser.parseAndCreate(nameInput.text);
        }
    }

    public void setInfoText(string text)
    {
        infoText.text = text;
    }

    public void destroyPrevMolecule()
    {
        Destroy(GameObject.Find("Molecule"));
    }
}