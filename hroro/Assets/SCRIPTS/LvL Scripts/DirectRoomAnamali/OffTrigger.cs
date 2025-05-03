using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OffTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Monster;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("false");
            Monster.SetActive(false);
        }
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
