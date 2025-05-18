using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLighttrigger : MonoBehaviour
{
    [SerializeField] private GameObject Monster;
    [SerializeField] private Light Light;
    [SerializeField] private GameObject Trigger;
    [SerializeField] private AudioSource source;
    private bool SetActive = true;

    void Start()
    {
        Monster.SetActive(false);
        GameObject Flashlight = GameObject.Find("Flashlight");
        Light = Flashlight.transform.GetChild(0).GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnMonster());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && SetActive == true)
        {
            Light.enabled = false;
            SetActive = false;
            Trigger.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public IEnumerator SpawnMonster()
    {
        if (Light.enabled == true && SetActive == false && !source.isPlaying)
        {;
            Monster.SetActive(true);
            source.Play();
            yield return new WaitForSeconds(1f);
            Monster.SetActive(false);
            SetActive = true;
        }
    }
}
