using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Atom : MonoBehaviour
{
    private GameObject sphere;

    public Atom()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    public Atom(Vector3 initPosition)
    {

        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = initPosition;

    }

    public void setMaterial(Material material)
    {
        sphere.GetComponent<Renderer>().material = material;
    }

    public void setPosition(Vector3 position)
    {
        sphere.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
