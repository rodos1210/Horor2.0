using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIsPlaying : MonoBehaviour
{
    public static bool IsPlaying;
    public void StartAnimPlay()
    {
        IsPlaying = true;
    }
    public void StopAnimPlay()
    {
        IsPlaying = false;
    }
}
