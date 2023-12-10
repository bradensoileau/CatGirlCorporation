using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Make sure to assign the player tag in the Unity editor

    public string type;
    public GameObject player;
    public PlayerStats playerStats;
    public string playerTag = "Player";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();     
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Debug.Log("Power Up acquired by: " + gameObject.name);
        playerStats.HealDamage(30);
        gameObject.SetActive(false); // Deactivate the powerup object
    }
}