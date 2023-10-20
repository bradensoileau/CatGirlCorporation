using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerDeath playerDeath;
    public float health;
    private AudioSource audioSource;

    private void Start()
    {
        health = 60f;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            playerDeath.Kill();
        }
    }
}
