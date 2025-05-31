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
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        Move.y = gravity;
        controller.Move(Move * SpeedMove * Time.deltaTime);
    }
}
