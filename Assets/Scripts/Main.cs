using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Main : MonoBehaviour
{
    [SerializeField] public TMP_InputField moleculeInput;
    [SerializeField] public TMP_Dropdown dropdown_menu;
    [SerializeField] public TMP_Text infoText;
    [SerializeField] public Button spawn_button;
    [SerializeField] public Slider size_slider;
    [SerializeField] public AtomFactory atomFactory;
    [SerializeField] public GameObject temp;
    [SerializeField] public float rotationSpeed = 20;
    [SerializeField] public Camera cam;
    [SerializeField] public int conformationMaxDepth = 1;

    private Molecule _currentMolecule;
    public Molecule CurrentMolecule
    {
        get { return _currentMolecule; }
        set
        {
            _currentMolecule = value;
            if(_currentMolecule != null) AlignMolecule(_currentMolecule);
        }
    }

    private NameParser nameParser;
    void Start()
    {
        nameParser = new NameParser(this,atomFactory);
        spawn_button.onClick.AddListener(SpawnButtonAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentMolecule != null)
        {
            CurrentMolecule.MoleculeTransform.gameObject.transform.localScale = new Vector3(size_slider.value, size_slider.value, size_slider.value);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            nameParser.parseAndCreate(moleculeInput.text);
        }
        if(Input.GetMouseButton(0) && CurrentMolecule != null)
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;

            Vector3 right = Vector3.Cross(cam.transform.up, CurrentMolecule.Position - cam.transform.position);
            Vector3 up = Vector3.Cross(CurrentMolecule.Position - cam.transform.position, right);
            CurrentMolecule.Rotation = Quaternion.AngleAxis(-rotX, up) * CurrentMolecule.Rotation;
            CurrentMolecule.Rotation = Quaternion.AngleAxis(rotY, right) * CurrentMolecule.Rotation;
        }
    }

    public void SpawnButtonAction()
    {
        if (dropdown_menu.captionText.text != "Select an alkane")
        {
            nameParser.parseAndCreate(dropdown_menu.captionText.text);
        }
    }

    public void setInfoText(string text)
    {
        infoText.text = text;
    }

    public void destroyPrevMolecule()
    {
        StructureFactory.ResetCounts();
        Destroy(GameObject.Find("Molecule"));
        CurrentMolecule = null;
    }

    public void AlignMolecule(Molecule molecule)
    {
        List<MoleculeNode> nodes = CurrentMolecule.mainNode.GetAllNodesWithAtom<CarbonAtom>();
        float count = nodes.Count;
        Vector3 total = nodes.Aggregate<MoleculeNode, Vector3>(new Vector3(0f, 0f, 0f), (sum, node) =>
           {
               sum += node.NodeStructure.Position;
               return sum;
           });
        Vector3 shift = total / count;
        List<MoleculeNode> allNodes = CurrentMolecule.mainNode.GetAllNodes();
        foreach (MoleculeNode node in allNodes)
        {
            node.NodeStructure.Position -= shift;
        }
        CurrentMolecule.Rotation = Quaternion.FromToRotation(shift, Vector3.right);
    }

}