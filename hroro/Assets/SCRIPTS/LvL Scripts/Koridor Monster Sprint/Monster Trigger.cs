using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Monster;
    private bool StartMove = false;
    [SerializeField] GameObject MonsterTrig;
    [SerializeField] AudioSource source;
    void Start()
    {
        if (MonsterTrig.transform.position.z < 0)
        {
            Monster.transform.Rotate(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartMove == true && MonsterTrig.transform.position.z > 0)
        {
            Invoke("MoveMonsterPlusZ", 1f);
        }
        else if (StartMove == true && MonsterTrig.transform.position.z < 0)
        {
            Invoke("MoveMonsterMinusZ", 1f);
        }
        if ((Monster.transform.position == new Vector3(-2.49f, 1.451f, 9f) || Monster.transform.position == new Vector3(-2.49f, 1.451f, -19.5f)) && source.isPlaying)
        {
            source.Stop();
            Monster.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartMove = true;
        }    
    }

    private void MoveMonsterPlusZ()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        Monster.transform.position = Vector3.MoveTowards(Monster.transform.position, new Vector3(-2.49f,1.451f,9f), 5f * Time.deltaTime);
    }
    private void MoveMonsterMinusZ()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        Monster.transform.position = Vector3.MoveTowards(Monster.transform.position, new Vector3(-2.49f, 1.451f, -19.5f), 5f * Time.deltaTime);
    }
}
