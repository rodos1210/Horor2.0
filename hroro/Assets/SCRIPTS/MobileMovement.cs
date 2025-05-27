using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // скорость перемещения
    public Joystick joystick;    // ссылка на компонент джойстика

    private CharacterController characterController;
    private Vector3 moveDirection;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Получение входных данных с джойстика (от -1 до 1)
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Создаем направление движения относительно камеры или мира
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

        if (inputDirection.magnitude > 0.1f)
        {
            // Направление движения в мировых координатах
            Vector3 moveDir = inputDirection.normalized;

            // Можно добавить вращение игрока в сторону движения (по желанию)
            // transform.forward = moveDir;

            // Перемещение с учетом скорости
            moveDirection = moveDir * moveSpeed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        // Гравитация
        if (!characterController.isGrounded)
        {
            moveDirection += Physics.gravity * Time.deltaTime;
        }

        // Перемещение CharacterController
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
