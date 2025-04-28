using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSphere : MonoBehaviour, IInteractable
{
    public string GetHint()
    {
        return "Нажмите E чтобы сделать ченить";
    }

    public void Interact()
    {
        Debug.Log("Мы нажали на сферу");        
    }

    public void OnCursorIn()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnCursorOut()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
