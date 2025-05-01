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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
