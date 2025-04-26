using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiftDoorSecond : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public AudioSource sr;
    public AudioClip ad;

    public bool InLift;
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("StartOpenDoorLift", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        VneLift();
        StartCoroutine(Lift2());
    }

    public void StartOpenDoorLift()
    {
        anim.SetBool("Is Open for lift2", true);
    }


    public IEnumerator Lift2()
    {
        if (player.transform.position.z > 10.55f && InLift == true)
        {
            InLift = false;
            anim.SetBool("Is Open for lift2", false);
            sr.clip = ad;
            sr.Play();
            yield return new WaitForSeconds(4f);
            anim.SetBool("Is Open for lift2", true);
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
