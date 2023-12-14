using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BasicEnemyDamage : MonoBehaviour
{
    public float attackDamage = 1f;
    public GameObject player;
    public float attackCooldown = 3f; // Cooldown time in seconds
    private float timeSinceLastAttack = 0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && timeSinceLastAttack >= attackCooldown)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (timeSinceLastAttack >= attackCooldown)
        {
            timeSinceLastAttack = 0f; // Reset the cooldown timer
            ApplyDamage();
        }
    }
    private void ApplyDamage()
    {
        if (player != null)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(attackDamage);
            }
        }
    }

}

