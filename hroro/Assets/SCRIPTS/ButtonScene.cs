using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("First Scene");
    }
}
