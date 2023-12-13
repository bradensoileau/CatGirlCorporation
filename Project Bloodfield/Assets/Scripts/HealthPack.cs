using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Powerup
{
    public PlayerStats playerStats;

    // Finds the Player and Finds their stats
    new void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");  
        playerStats = player.GetComponent<PlayerStats>();    
    }

    // Gives Health
    void Pickup()
    {
        Debug.Log("Power Up acquired by: " + gameObject.name);
        playerStats.HealDamage(30);
        gameObject.SetActive(false); // Deactivate the powerup object
    }
}
