using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LVLSwaper : MonoBehaviour
{
    public List<GameObject> lvl = new List<GameObject>();

    public GameObject pref1;
    public GameObject pref2;
    public GameObject pref3;

    private int index;
    private int maxindex = 3;
    private GameObject sceneobject;
    public GameObject Player;

    public GameObject lift1;
    public GameObject lift2;
    public GameObject reset1;
    public GameObject reset2;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        lvl.Add(pref1);
        lvl.Add(pref2);
        lvl.Add(pref3);
        transform.position = new Vector3(0, 0, 0);
        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        Player.transform.position = new Vector3(-2, 1, -19);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HaveAnamali"))
        {
            lvl.RemoveAt(index);
            maxindex -= 1;
            Destroy(sceneobject);
            lift1.tag= "Untagged";
            reset1.tag = "Reset1";
            reset2.tag = "Reset1";
            if (Player.transform.position.z >10)
            {
                SpawnObjectsForHA();
            }
            else
            {
                SpawnObjectsForDHA();
            }
        }
        else if (other.gameObject.CompareTag("DontHaveAnamali"))
        {
            lvl.RemoveAt(index);
            maxindex -= 1;
            Destroy(sceneobject);
            lift2.tag = "Untagged";
            reset1.tag = "Reset2";
            reset2.tag = "Reset2";
            if (Player.transform.position.z < -10)
            {
                SpawnObjectsForDHA();
            }
            else
            {
                SpawnObjectsForHA();
            }
        }
        else if (reset1.tag == "Reset1" || reset2.tag == "Reset1")
        {
            lift1.tag = "DontHaveAnamali";
            lift2.tag = "HaveAnamali";
            reset1.tag = "Untagged";
            reset2.tag = "Untagged";
        }
        else if (reset2.tag == "Reset2" || reset1.tag == "Reset2")
        {
            lift1.tag = "HaveAnamali";
            lift2.tag = "DontHaveAnamali";
            reset1.tag = "Untagged";
            reset2.tag = "Untagged";
        }
    }
    public void SpawnObjectsForDHA()
    {
        index = UnityEngine.Random.Range(0,maxindex);
        transform.position = new Vector3(0, 0, 0);
        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        
        
    }
    public void SpawnObjectsForHA()
    {
        index = UnityEngine.Random.Range(0, maxindex);
        transform.position = new Vector3(-4.74f, 0, -10.06f);
        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        sceneobject.transform.Rotate(0, 180, 0);
    }
}