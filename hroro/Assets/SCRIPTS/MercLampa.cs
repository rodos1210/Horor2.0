using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercLampa : MonoBehaviour
{
    private float minIntensity = 10f;
    private float maxIntensity = 20f;
    private float flickerSpeed = 0.1f;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        StartCoroutine(DoFlicker());
    }

    IEnumerator DoFlicker()
    {
        while (true)
        {
            lightComponent.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }


}
