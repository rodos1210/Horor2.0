using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public interface IInteractable
{
    string GetHint();
    void OpenDoor();
    void CloseDoor();
    void SystemDoor();
}
