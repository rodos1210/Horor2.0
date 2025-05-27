using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �����������
    public Joystick joystick;    // ������ �� ��������� ���������

    private CharacterController characterController;
    private Vector3 moveDirection;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ��������� ������� ������ � ��������� (�� -1 �� 1)
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // ������� ����������� �������� ������������ ������ ��� ����
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

        if (inputDirection.magnitude > 0.1f)
        {
            // ����������� �������� � ������� �����������
            Vector3 moveDir = inputDirection.normalized;

            // ����� �������� �������� ������ � ������� �������� (�� �������)
            // transform.forward = moveDir;

            // ����������� � ������ ��������
            moveDirection = moveDir * moveSpeed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        // ����������
        if (!characterController.isGrounded)
        {
            moveDirection += Physics.gravity * Time.deltaTime;
        }

        // ����������� CharacterController
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
