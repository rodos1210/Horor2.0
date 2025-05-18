using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject Triger;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject Door;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] ForScreem;
    [SerializeField] private string DoorOpenAnimName, DoorCloseAnimName;

    private bool TrigerClose;
    void Start()
    {
        Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnMonster());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
        }
    }
    public IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.5f);
        Animator anim = Door.GetComponent<Animator>();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorOpenAnimName))
        {
            anim.ResetTrigger("open");
            anim.SetTrigger("close");
            if (DoorIsPlaying.IsPlaying == false)
            {
                source.clip = ForScreem[0];
                source.Play();
            }
        }
        Triger.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        TrigerClose = true;
    }
    public IEnumerator SpawnMonster()
    {
        Animator anim = Door.GetComponent<Animator>();
        if (DoorIsPlaying.IsPlaying == false && TrigerClose == true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorOpenAnimName))
            {
                Monster.SetActive(true);
                source.clip = ForScreem[1];
                source.Play();
                TrigerClose = false;
                yield return new WaitForSeconds(1f);
                Monster.SetActive(false);
            }
        }
    }
}
