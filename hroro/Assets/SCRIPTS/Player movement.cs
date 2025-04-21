using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [Header("Steps")]
    public AudioSource audioSource;
    public AudioClip walkSound;
    public KeyCode walkKey = KeyCode.W; 
    public float soundCooldown = 0.5f; 
    private float timer;


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
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HendleLook();
        HandleMove();

        if (Input.GetKey(walkKey))
        {
            timer += Time.deltaTime;
            if (timer >= soundCooldown)
            {
                PlayWalkSound();
                timer = 0;
            }
        }

        else
        {
            timer = soundCooldown;
        }
    }
    void PlayWalkSound()
    {
        if (audioSource && walkSound)
        {
            audioSource.PlayOneShot(walkSound);
        }
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
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = transform.TransformDirection(input) * speed;

        if (controller.isGrounded && vertikalSpeed < 0)
        {
            vertikalSpeed = -2f;
        }
        vertikalSpeed += gravity * Time.deltaTime;
        move.y = vertikalSpeed;
        controller.Move(move * Time.deltaTime);
    }
}
