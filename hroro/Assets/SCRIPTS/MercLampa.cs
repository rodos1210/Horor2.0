using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercLampa : MonoBehaviour
{
    public float minIntensity = 2f;
    public float maxIntensity = 5f;
    public float flickerSpeed = 0.1f;

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
