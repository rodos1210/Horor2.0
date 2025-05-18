using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LVLSwaper : MonoBehaviour
{
    public List<GameObject> lvl = new List<GameObject>();

    private int index;
    private int maxindex = 3;
    private GameObject sceneobject;
    public GameObject Player;

    public GameObject lift1;
    public GameObject lift2;
    public GameObject reset1;
    public GameObject reset2;

    public MeshRenderer MeshRenderer1;
    public MeshRenderer MeshRenderer2;
    public Material[] NumberMaterials;
    private int NumberMaterialCounter;

    private int FirstTryCounter;

    private LiftDoor LiftDoor;

    // Start is called before the first frame update
    void Start()
    {
        NumberMaterialCounter = 0;
        MeshRenderer1.material = NumberMaterials[NumberMaterialCounter];
        MeshRenderer2.material = NumberMaterials[NumberMaterialCounter];

        LiftDoor = GetComponent<LiftDoor>();
        index = 0;

        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        sceneobject.transform.position = new Vector3(0, 0, 0);
        Player.transform.position = new Vector3(-2.5f, 1, -21);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("firsttry"))
        {
            FirstTryCounter = 1;
        }
        if (other.gameObject.CompareTag("HaveAnamali") && FirstTryCounter == 1)
        {
            if (lvl[index].CompareTag("Anamali Lvl"))
            {
                NumberMaterialCounter++;
                MeshRenderer1.material = NumberMaterials[NumberMaterialCounter];
                MeshRenderer2.material = NumberMaterials[NumberMaterialCounter];
            }
            else
            {
                NumberMaterialCounter = 0;
                MeshRenderer1.material = NumberMaterials[NumberMaterialCounter];
                MeshRenderer2.material = NumberMaterials[NumberMaterialCounter];
            }

            lift1.tag = "Untagged";
            lvl.RemoveAt(index);
            maxindex -= 1;
            Destroy(sceneobject,2f);
            reset1.tag = "Reset1";
            reset2.tag = "Reset1";
            if (Player.transform.position.z >10)
            {
                Invoke("SpawnObjectsForHA", 3f);
            }
            else
            {
                Invoke("SpawnObjectsForDHA", 3f);
            }
        }
        else if (other.gameObject.CompareTag("DontHaveAnamali") && FirstTryCounter == 1)
        {
            if (lvl[index].CompareTag("Not Anamali Lvl"))
            {
                NumberMaterialCounter++;
                MeshRenderer1.material = NumberMaterials[NumberMaterialCounter];
                MeshRenderer2.material = NumberMaterials[NumberMaterialCounter];
            }
            else
            {
                NumberMaterialCounter = 0;
                MeshRenderer1.material = NumberMaterials[NumberMaterialCounter];
                MeshRenderer2.material = NumberMaterials[NumberMaterialCounter];
            }

            lift2.tag = "Untagged";
            lvl.RemoveAt(index);
            maxindex -= 1;
            Destroy(sceneobject,2f);
            reset1.tag = "Reset2";
            reset2.tag = "Reset2";
            if (Player.transform.position.z < -10)
            {
                Invoke("SpawnObjectsForDHA",3f);
            }
            else
            {
                Invoke("SpawnObjectsForHA", 3f);
            }
        }
        if (other.gameObject.CompareTag("Reset2"))
        {
            lift1.tag = "HaveAnamali";
            lift2.tag = "DontHaveAnamali";
            reset1.tag = "Static";
            reset2.tag = "Static";
        }
        else if (other.gameObject.CompareTag("Reset1"))
        {
            lift1.tag = "DontHaveAnamali";
            lift2.tag = "HaveAnamali";
            reset1.tag = "Static";
            reset2.tag = "Static";
        }
        


        if (other.gameObject.CompareTag("Monster"))
        {
            RestartGame();
        }



    }
    public void SpawnObjectsForDHA()
    {
        index = UnityEngine.Random.Range(0,maxindex);
        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        sceneobject.transform.position = new Vector3(0, 0, 0);
    }
    public void SpawnObjectsForHA()
    {
        index = UnityEngine.Random.Range(0, maxindex);
        sceneobject = Instantiate(lvl[index], transform.position, Quaternion.identity);
        sceneobject.transform.position = new Vector3(-4.74f, 0, -10f);
        sceneobject.transform.Rotate(0, 180, 0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Player.transform.position = new Vector3(-2.5f, 1, -21);
    }
}
