using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light Light;
    public AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Light.enabled == false)
            {
                source.Play();
                Light.enabled = true;
            }
            else
            {
                source.Play();
                Light.enabled = false;
            }
        }
    }
}
