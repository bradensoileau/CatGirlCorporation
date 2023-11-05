using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //To of course mange our music
    public MusicManager manager;

    private const string TitleSceneName = "TitleScreen";
    //eventualy make getters and setters because I hate global variables
    public bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        HandlePauseInput();
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //integral to use the music manger as it handels pausing and switching between tracks in the music manger object
                //it will pause current music in our Music manger object name manger. then play the track associated with the state
                manager.Pause();
                manager.SwitchToLevelMusic();
                ResumeGame();
            }
            else
            {
                manager.Pause();
                manager.SwitchToPauseMenuMusic();
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        manager.Pause();
        manager.SwitchToLevelMusic();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(TitleSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
