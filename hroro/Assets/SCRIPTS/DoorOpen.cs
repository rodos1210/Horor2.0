using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float distance;
    [SerializeField] private GameObject cam;
    private int counter = 1;
    bool keypress = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, distance, Layer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (keypress == false)
                {
                    anim.SetBool("Is Open", true);
                    keypress = true;
                }
                else
                {
                    anim.SetBool("Is Open", false);
                    keypress = false;
                }
            }
        }
    }
}
