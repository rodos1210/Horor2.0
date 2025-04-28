using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSphere : MonoBehaviour, IInteractable
{
    public string GetHint()
    {
        return "������� E ����� ������� ������";
    }

    public void Interact()
    {
        Debug.Log("�� ������ �� �����");        
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
