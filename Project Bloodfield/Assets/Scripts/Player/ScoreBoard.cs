using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + 0;
    }

    public int playerScore = 0;
    public void AddScore(int points)
    {
        playerScore += points;
        UpdateScore(playerScore);
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + (playerScore).ToString();
    }


}