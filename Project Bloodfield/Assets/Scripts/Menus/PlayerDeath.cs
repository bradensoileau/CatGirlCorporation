using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    private const string TitleSceneName = "TitleScreen";
    private const string Level2SceneName = "02Level";
    public GameObject playerDeath;
    public GameObject healthBar;
    public MusicManager manger;
    public GameObject bossHealthBar;
    // Update is called once per frame
    void Start()
    {
        playerDeath.SetActive(false);
    }
    
    public void Kill()
    {
        healthBar.SetActive(false);
        playerDeath.SetActive(true);
        bossHealthBar.SetActive(false);
        Time.timeScale = 0f;
        manger.Pause();
        manger.SwitchToGameOverMusic();
    }
    public void PlayAgain()
    {
        playerDeath.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(Level2SceneName);
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