using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggger : MonoBehaviour
{
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject Triger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Monster.SetActive(false);
        }
    }
}
