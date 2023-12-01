using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public void HealDamage(float healAmount)
    {
        health += healAmount;

        
        if(health >= 60)
        {
            health = 60;
        }
        
    }
}
