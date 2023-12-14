using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class SpeedPowerup : Powerup
{
    public Movement movement;
    public Renderer rend;
    //public string playerTag = "Player";

    // Find the player and their movement
    new void Start()
    { 
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        movement = player.GetComponent<Movement>();    
    }

    protected new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Pickup();
        }
    }

    // Gives Speed Boost
    void Pickup()
    {
        Debug.Log("Power Up acquired by: sped" + gameObject.name);
        StartCoroutine(GiveSpeedBoost());
        //gameObject.SetActive(false); // Deactivate the powerup object
    }

    IEnumerator GiveSpeedBoost()
    {
        movement.speed = 15f;
        rend.enabled = false;
        yield return new WaitForSeconds(5);
        Debug.Log("Powerup over" + gameObject.name);
        movement.speed = 5f;
        gameObject.SetActive(false);
    }
}
