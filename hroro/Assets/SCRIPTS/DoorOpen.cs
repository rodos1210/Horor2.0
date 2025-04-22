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
    bool keypress = false;

    [SerializeField] private AudioClip opendoor;
    [SerializeField] private AudioClip closedoor;
    [SerializeField] private AudioSource source;
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
                    source.clip = opendoor;
                    source.Play();
                }
                else
                {
                    anim.SetBool("Is Open", false);
                    keypress = false;
                    source.clip = closedoor;
                    source.Play();
                }
            }
        }
    }
}
