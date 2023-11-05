using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    public GameObject player;
    private float maxHealth;
    public PlayerStats playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerStats>();
        maxHealth = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealth = playerHealth.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

}
