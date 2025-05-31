using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject MobileButton;
    public enum PlatformType
    {
        PC,
        Mobile,
        Other
    }

    public static PlatformType CurrentPlatform { get; private set; }

    void Awake()
    {
        DetectPlatform();
        Debug.Log("Текущая платформа: " + CurrentPlatform);
    }

    private void DetectPlatform()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
            CurrentPlatform = PlatformType.PC;
#elif UNITY_IOS || UNITY_ANDROID
            CurrentPlatform = PlatformType.Mobile;
#else
            CurrentPlatform = PlatformType.Other;
#endif
    }

    private void Start()
    {
        if (CurrentPlatform == PlatformType.Mobile || CurrentPlatform == PlatformType.Other)
        {
            Player.GetComponent<MobileMovement>().enabled = true;
            Camera.GetComponent<CamMobileMovement>().enabled = true;
            Player.GetComponent<Playermovement>().enabled = false;
            MobileButton.SetActive(true);
        }
        else if (CurrentPlatform == PlatformType.PC)
        {
            Player.GetComponent<MobileMovement>().enabled = false;
            Camera.GetComponent<CamMobileMovement>().enabled = false;
            Player.GetComponent<Playermovement>().enabled = true;
            MobileButton.SetActive(false);
        }
    }
}
