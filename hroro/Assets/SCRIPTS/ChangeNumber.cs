using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNumber : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Material[] Materials;
    void Start()
    {
        Renderer.material = Materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
