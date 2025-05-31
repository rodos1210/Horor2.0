using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CamMobileMovement : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float sensitivityPanelRotate = 1; // „увствительность мыши
    public float maxYAngle = 80.0f; // ћаксимальный угол вращени€ по вертикали
    public FixTouch cameraControllerPanel;
    private float rotationX = 0.0f;
    public GameObject Player;

    private void Update()
    {
        float mouseX = 0;
        float mouseY = 0;
            if (cameraControllerPanel.pressed)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.fingerId == cameraControllerPanel.fingerId)
                    {
                        if (touch.phase == TouchPhase.Moved)
                        {
                            mouseY = touch.deltaPosition.y * sensitivityPanelRotate;
                            mouseX = touch.deltaPosition.x * sensitivityPanelRotate;
                        }

                        if (touch.phase == TouchPhase.Stationary)
                        {
                            mouseY = 0;
                            mouseX = 0;
                        }
                    }
                }
            }

        // ¬ращаем персонажа в горизонтальной плоскости
        Player.transform.Rotate(Vector3.up * mouseX * sensitivity);

        // ¬ращаем камеру в вертикальной плоскости
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}