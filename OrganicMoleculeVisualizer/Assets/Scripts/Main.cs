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

    private NameParser nameParser;
    void Start()
    {
        nameParser = new NameParser(atomFactory);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            infoText.text = nameParser.parseAndCreate(nameInput.text);
        }
    }

    
}