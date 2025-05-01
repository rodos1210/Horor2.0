using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string GetHint();
    void OpenDoor();
    void CloseDoor();
}
