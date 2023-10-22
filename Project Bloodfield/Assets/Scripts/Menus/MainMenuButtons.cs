using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private const string Level1SceneName = "Level1";
    public AudioSource audioSource;

    public void PlayGame ()
    {
        audioSource.Stop();
        Debug.Log("Load1");
        SceneManager.LoadScene(Level1SceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
