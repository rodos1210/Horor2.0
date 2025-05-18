using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ActiveTriger;
    [SerializeField] private GameObject MonsterTrigger;
    [SerializeField] private GameObject Monster;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MonsterTrigger.SetActive(true);
            Monster.SetActive(true);
            ActiveTriger.SetActive(false);
        }
    }
}
