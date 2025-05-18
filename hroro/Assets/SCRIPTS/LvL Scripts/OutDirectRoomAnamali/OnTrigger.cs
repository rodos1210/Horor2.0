using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Monster;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("false");
            Monster.SetActive(true);
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
