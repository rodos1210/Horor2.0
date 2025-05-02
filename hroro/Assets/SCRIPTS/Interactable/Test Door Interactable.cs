using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class TestDoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip opendoor;
    [SerializeField] private AudioClip closedoor;
    public string DoorOpenAnimName, DoorCloseAnimName;
    public void CloseDoor()
    {
            anim.SetBool("Is Open", false);
            source.clip = closedoor;
            source.Play();
    }

    public string GetHint()
    {
        return "ֽאזלטעו E";
    }


    public void OpenDoor()
    {
            anim.SetBool("Is Open", true);
            source.clip = opendoor;
            source.Play();
    }

    public void SystemDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorOpenAnimName))
            {
                anim.ResetTrigger("open");
                anim.SetTrigger("close");
                source.clip = opendoor;
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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
