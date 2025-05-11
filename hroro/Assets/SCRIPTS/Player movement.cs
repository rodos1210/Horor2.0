using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Playermovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float walkspeed = 2f;
    [SerializeField] private float runspeed = 3f;
    [SerializeField] private float gravity = -9.8f;

    [Header("Camera")]
    [SerializeField] private Camera virtualcamera;
    [SerializeField] private Transform camerapivot;
    [SerializeField] private float mouseSensivity = 2f;


    private CharacterController controller;
    private float vertikalSpeed;
    

    public AudioClip footstepSound;
    [SerializeField] private AudioSource audioSource;
    private float _vertical;
    private float _horizontal;
    void Start()
    {

        audioSource.clip = footstepSound;

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HendleLook();
        HandleMove();
    }


    private void HendleLook()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSensivity;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensivity;
        transform.Rotate(Vector2.up * mousex);

        float vertivalRotation = -mousey; // координаты мыши 2д
        float currentCAmeraAngel = camerapivot.localEulerAngles.x; // координаты камеры 3д + угол наклона
        float newAngel = currentCAmeraAngel + vertivalRotation;
        if (newAngel > 180)
        {
            newAngel -= 360;
            newAngel = Mathf.Clamp(newAngel, -90, 90); // не дает выйти за пределы 90 и -90
        }

        camerapivot.localEulerAngles = new Vector3(newAngel, 0, 0);

    }
    private void HandleMove()
    {
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runspeed;
        }
        else
        {
            speed = walkspeed;
        }

        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        Vector3 input = new Vector3(_horizontal, 0, _vertical);
        Vector3 move = transform.TransformDirection(input) * speed;

        if (controller.isGrounded && vertikalSpeed < 0)
        {
            vertikalSpeed = -2f;
        }
        vertikalSpeed += gravity * Time.deltaTime;
        move.y = vertikalSpeed;
        controller.Move(move * Time.deltaTime);

        if (_vertical!=0.0f || _horizontal!=0.0f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
/*        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }*/
    }
}
