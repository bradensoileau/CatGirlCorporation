using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public string sceneName;
    public void PlayGame ()
    {
        SceneManager.LoadScene(sceneName);
    }

}
