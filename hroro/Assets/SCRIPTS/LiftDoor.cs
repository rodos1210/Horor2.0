using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public AudioSource sr;
    public AudioClip ad;
    public AudioClip adstart;
    public bool InLift;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr.clip = adstart;
        sr.Play();
        Invoke("StartOpenDoorLift", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        VneLift();
        StartCoroutine(Lift1());
    }

    public void StartOpenDoorLift()
    {
        anim.SetBool("Is Open for lift1", true);
    }



    public IEnumerator Lift1()
    {
        if (player.transform.position.z < -20.65f && InLift == true)
        {
            InLift = false;
            anim.SetBool("Is Open for lift1", false);
            sr.clip = ad;
            sr.Play();
            yield return new WaitForSeconds(4f);
            anim.SetBool("Is Open for lift1", true);
        }
    }
    public void VneLift()
    {
        if (player.transform.position.z > -19.64f && player.transform.position.z < 9.46f)
        {
            InLift = true;
        }
    }
}
