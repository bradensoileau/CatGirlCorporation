using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public string sceneName;
    public AudioSource audioSource;

    public void PlayGame ()
    {
        audioSource.Stop();
        Debug.Log("Load1");
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
