using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Sphere;
    public GameObject Cylinder;
    void Start() {
        
    }
    
    void Update()
    {
        if (Input.GetKey("q")) Instantiate(Cube, transform);
        if (Input.GetKey("s")) Instantiate(Sphere, transform);
        if (Input.GetKey("d")) Instantiate(Cylinder, transform);
    }
}

