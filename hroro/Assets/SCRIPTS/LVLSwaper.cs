using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LVLSwaper : MonoBehaviour
{
    public List<GameObject> lvl = new List<GameObject>();

    public GameObject pref1;
    public GameObject pref2;

    private int index;
    private int maxindex = 2;
    private GameObject sceneobject;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        lvl.Add(pref1);
        lvl.Add(pref2);
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
            SpawnObjects();
        }
        else if (other.gameObject.CompareTag("DontHaveAnamali"))
        {
            lvl.RemoveAt(index);
            maxindex -= 1;
            Destroy(sceneobject);
            SpawnObjects();
        }
    }
    public void SpawnObjects()
    {
        index = UnityEngine.Random.Range(0,maxindex);
        transform.position = new Vector3(0, 0, 0);
        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        
        
    }
}