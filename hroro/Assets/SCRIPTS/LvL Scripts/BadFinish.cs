using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadFinish : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource ScreemSource;
    [SerializeField] private GameObject Monster;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(true);
            PravilaButton.Press = false;
            source.Play();
            Monster.SetActive(false);
            PlayerInteract.tp =false;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
