using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject MobileButton;
    [SerializeField] private Material material;
    public Shader PcShader;
    public Shader MobileShader;
    public static bool platform;
    void Start()
    {
        // Ждём, пока SDK не инициализируется
        if (YandexGame.SDKEnabled)
        {
            CheckDevice();
        }
        else
        {
            YandexGame.GetDataEvent += CheckDevice;
        }
    }

    void CheckDevice()
    {
        string device = YandexGame.EnvironmentData.deviceType;

        switch (device)
        {
            case "mobile":
                platform = true;
                Player.GetComponent<Playermovement>().enabled = false;
                Player.GetComponent<MobileMovement>().enabled = true;
                Camera.GetComponent<CamMobileMovement>().enabled = true;
                MobileButton.SetActive(true);
                Debug.Log("mobile");
                material.shader = MobileShader;
                break;
            case "desktop":
                platform = false;
                Player.GetComponent<Playermovement>().enabled = true;
                Player.GetComponent<MobileMovement>().enabled = false;
                Camera.GetComponent<CamMobileMovement>().enabled = false;
                MobileButton.SetActive(false);
                Debug.Log("PC");
                material.shader = PcShader;
                break;
            case "tablet":
                platform = true;
                Player.GetComponent<Playermovement>().enabled = false;
                Player.GetComponent<MobileMovement>().enabled = true;
                Camera.GetComponent<CamMobileMovement>().enabled = true;
                MobileButton.SetActive(true);
                material.shader = MobileShader;
                break;
            default:
                Debug.Log("Платформа не определена: " + device);
                break;
        }

        // Отписываемся, чтобы не вызывался снова
        YandexGame.GetDataEvent -= CheckDevice;
    }
}
