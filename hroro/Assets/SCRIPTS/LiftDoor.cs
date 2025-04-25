using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{
    public Animator anim;
    public GameObject player;

    private bool InLift;
    void Start()
    {
        InLift = true;
        anim = GetComponent<Animator>();
        Invoke("StartOpenDoorLift", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Lift2());
        StartCoroutine(Lift1());
    }

    public void StartOpenDoorLift()
    {
        anim.SetBool("Is Open for lift1", true);
        anim.SetBool("Is Open for lift2", true);
    }


    public IEnumerator Lift2()
    {
        if (player.transform.position.z > 10.279f)
        {
            anim.SetBool("Is Open for lift2", false);
            yield return new WaitForSeconds(5f);
            anim.SetBool("Is Open for lift2", true);
        }
    }
    public IEnumerator Lift1()
    {
        if (player.transform.position.z < -20.39f)
        {
            anim.SetBool("Is Open for lift1", false);
            yield return new WaitForSeconds(5f);
            anim.SetBool("Is Open for lift1", true);
        }
    }
}
