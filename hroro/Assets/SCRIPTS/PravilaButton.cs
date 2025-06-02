using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PravilaButton : MonoBehaviour
{
    [SerializeField] private GameObject Pravila;
    public static bool Press = false;

    public void PressKnopka()
    {
        Pravila.SetActive(false);
        Press = true;
    }

    private void Start()
    {
        Press = false;
    }
}
