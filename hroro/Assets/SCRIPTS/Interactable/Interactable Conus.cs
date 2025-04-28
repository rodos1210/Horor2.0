using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableConus : MonoBehaviour, IInteractable
{
    public string GetHint()
    {
        return "Нажмите E чтобы изменить цвет на 0.1 сек";
    }

    public void Interact()
    {

        Debug.Log("Мы нажали на сферу");
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void OnCursorIn()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void OnCursorOut()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
