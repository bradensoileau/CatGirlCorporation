using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class SpeedPowerup : Powerup
{
    public Movement movement;

    // Find the player and their movement
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");  
        movement = player.GetComponent<Movement>();    
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Pickup();
        }
    }

    // Gives Speed Boost
    void Pickup()
    {
        Debug.Log("Power Up acquired by: " + gameObject.name);
        GiveSpeedBoost();
        gameObject.SetActive(false); // Deactivate the powerup object
    }

    public async void GiveSpeedBoost()
    {
        movement.speed = 15;
        await Task.Delay(5000);
        movement.speed = 5;
    }
}