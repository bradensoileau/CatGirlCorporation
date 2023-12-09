using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Make sure to assign the player tag in the Unity editor

    public string type;
    public GameObject player;
    public string playerTag = "Player";

    // Finds the player
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");     
    }

    // When Collision
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Pickup();
        }
    }

    // BooWhomp
    void Pickup()
    {
        Debug.Log("Power Up acquired by: " + gameObject.name);
    }
}