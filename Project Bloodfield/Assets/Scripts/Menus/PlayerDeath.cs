using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    private const string TitleSceneName = "TitleScreen";
    private const string Level1SceneName = "Level1";
    public GameObject playerDeath;
    public GameObject healthBar;
    public MusicManager manger;
    // Update is called once per frame
    void Start()
    {
        playerDeath.SetActive(false);
    }
    
    public void Kill()
    {
        healthBar.SetActive(false);
        playerDeath.SetActive(true);
        Time.timeScale = 0f;
        manger.Pause();
        manger.SwitchToGameOverMusic();
    }
    public void PlayAgain()
    {
        playerDeath.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(Level1SceneName);
    }

    public void MainMenuButton()
    {
        playerDeath.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(TitleSceneName);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
