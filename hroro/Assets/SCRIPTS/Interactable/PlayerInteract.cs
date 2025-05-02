using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Text hintText;
    public string DoorOpenAnimName, DoorCloseAnimName;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip opendoor;
    [SerializeField] private AudioClip closedoor;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.gameObject.tag == "Door")
            {
                GameObject doorparent = hit.collider.transform.parent.gameObject;
                Animator anim = doorparent.GetComponentInParent<Animator>();
                hintText.text = "ֽאזלטעו E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorOpenAnimName))
                    {
                        anim.ResetTrigger("open");
                        anim.SetTrigger("close");
                        source.clip = closedoor;
                        source.Play();
                    }
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorCloseAnimName))
                    {
                        anim.ResetTrigger("close");
                        anim.SetTrigger("open");
                        source.clip = closedoor;
                        source.Play();
                    }
                }
            }
            else
            {
                hintText.text = "";
            }
        }
    }
}
