using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MobileMovement : MonoBehaviour
{

    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController controller;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] footstepSound;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        Move.y = gravity;
        controller.Move(Move * SpeedMove * Time.deltaTime);
        if (joystick.Horizontal!=0 || joystick.Vertical!=0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = 1.5f;
                audioSource.clip = footstepSound[Random.Range(0, footstepSound.Length)];
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }
    }
}
