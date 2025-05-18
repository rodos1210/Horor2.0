using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MenuLiftOpen : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.CompareTag("Door"))
            {
                animator.ResetTrigger("menuLiftClosee");
                animator.SetTrigger("menuLiftOpen");
            }
            else
            {

                animator.ResetTrigger("menuLiftOpen");
                animator.SetTrigger("menuLiftClosee");
            }
        }
        
    }
}
