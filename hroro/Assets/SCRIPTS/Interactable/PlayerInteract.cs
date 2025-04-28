using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Text hintText;

    private IInteractable lastInteractableObject; 
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            Debug.Log("Hit smth");
            IInteractable interactableObject;            
            if (hit.transform.TryGetComponent<IInteractable>(out interactableObject))
            {
                lastInteractableObject = interactableObject;
                interactableObject?.OnCursorIn();
                hintText.text = interactableObject.GetHint();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactableObject.Interact();
                    lastInteractableObject = null;
                }
            }                      
        }
        else
        {
            hintText.text = "";
            lastInteractableObject?.OnCursorOut();
            /*if (lastInteractableObject != null)
            {
                lastInteractableObject?.OnCursorOut();
            }*/
        }
    }
}
