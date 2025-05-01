using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Text hintText;
    private bool keypress = false;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            IInteractable interactableObject;
            if (hit.transform.TryGetComponent<IInteractable>(out interactableObject))
            {
                hintText.text = interactableObject.GetHint();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (keypress == false)
                    {
                        interactableObject.OpenDoor();
                        keypress = true;
                    }
                    else
                    {
                        interactableObject.CloseDoor();
                        keypress = false;
                    }
                }
            }                      
        }
        else
        {
            hintText.text = "";
            /*if (lastInteractableObject != null)
            {
                lastInteractableObject?.OnCursorOut();
            }*/
        }
    }
}
