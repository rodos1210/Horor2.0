using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Text hintText;
    public string DoorOpenAnimName, DoorCloseAnimName;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip opendoor;
    [SerializeField] private AudioClip closedoor;


    [SerializeField] private AudioSource muzic1;

    private bool PressButton;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject GoodFinishPanel;
    public static bool tp = false;
    void Update()
    {
        if (tp && cam.transform.position.z > 0)
        {
            GameObject Monster = GameObject.Find("Monster");
            Monster.transform.position = Monster.transform.position + new Vector3(0, 0, 0.027f);
        }
        else if (tp && cam.transform.position.z < 0)
        {
            GameObject Monster = GameObject.Find("Monster");
            Monster.transform.position = Monster.transform.position + new Vector3(0, 0, -0.027f);
        }

        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.gameObject.tag == "Door")
            {
                if (Platform.platform == true)
                {
                    Button.SetActive(true);
                }
                GameObject doorparent = hit.collider.transform.parent.gameObject;
                Animator anim = doorparent.GetComponentInParent<Animator>();
                hintText.text = "ќткрыть";
                if (Input.GetKeyDown(KeyCode.E) || PressButton==true)
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorOpenAnimName))
                    {
                        anim.ResetTrigger("open");
                        anim.SetTrigger("close");
                        if (DoorIsPlaying.IsPlaying == false)
                        {
                            source.clip = opendoor;
                            source.Play();
                        }
                    }
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName(DoorCloseAnimName))
                    {
                        anim.ResetTrigger("close");
                        anim.SetTrigger("open");
                        if (DoorIsPlaying.IsPlaying ==false)
                        {
                            source.clip = closedoor;
                            source.Play();
                        }
                    }
                    PressButton = false;
                }
            }
            else if (hit.collider.gameObject.tag == "Finish")
            {
                if (Platform.platform == true)
                {
                    Button.SetActive(true);
                }
                hintText.text = "—бежать";
                if (Input.GetKeyDown(KeyCode.E) || PressButton == true)
                {
                    GoodFinishPanel.SetActive(true);
                    PravilaButton.Press=false;
                    muzic1.Play();
                    PressButton=false;
                }
            }
            else if (hit.collider.gameObject.tag == "BadFinish")
            {
                if (Platform.platform == true)
                {
                    Button.SetActive(true);
                }
                GameObject Monster = GameObject.Find("Monster");
                hintText.text = "—бежать";
                if ((Input.GetKeyDown(KeyCode.E) || PressButton == true) && cam.transform.position.z > 0)
                {
                    if (tp==false)
                    {
                        Monster.transform.position = Monster.transform.position + new Vector3(0, 0, 11.05f);
                        tp = true;
                        Monster.GetComponent<AudioSource>().Play();
                    }
                }
                else if ((Input.GetKeyDown(KeyCode.E) || PressButton == true) && cam.transform.position.z < 0)
                {
                    if (tp == false)
                    {
                        Monster.transform.position = Monster.transform.position + new Vector3(0, 0, -11.05f);
                        tp = true;
                        Monster.GetComponent<AudioSource>().Play();
                    }
                }
                PressButton = false;
            }

            else
            {
                Button.SetActive(false);
                hintText.text = "";
            }
        }
        else
        {
            Button.SetActive(false);
            hintText.text = "";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BadMonster"))
        {
            GameObject Panel = GameObject.Find("Bad Finish Canvas");
            Panel.SetActive(true);
        }
    }

    public void TrueButton()
    {
        PressButton = true;
    }

    public void FalseButton()
    {
        PressButton = false;
    }
}
