using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Powerup
{
    public PlayerStats playerStats;

    // Finds the Player and Finds their stats
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");  
        playerStats = player.GetComponent<PlayerStats>();    
    }


    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Pickup();
        }
    }

    // Gives Health
    void Pickup()
    {
        Debug.Log("Power Up acquired by: " + gameObject.name);
        playerStats.HealDamage(30);
        gameObject.SetActive(false); // Deactivate the powerup object
    }
}
