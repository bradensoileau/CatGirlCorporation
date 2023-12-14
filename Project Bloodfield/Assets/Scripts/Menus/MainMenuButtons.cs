using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private const string Level1SceneName = "01Level";
    private const string Level2SceneName = "02Level";
    public AudioSource audioSource;

    public void PlayGame1 ()
    {
        audioSource.Stop();
        Debug.Log("Load1");
        SceneManager.LoadScene(Level1SceneName);
    }

    public void PlayGame2 ()
    {
        audioSource.Stop();
        Debug.Log("Load2");
        SceneManager.LoadScene(Level2SceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
