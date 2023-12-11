using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BasicEnemyDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
            while(collision.gameObject.CompareTag("Player"))
            {
                if(playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                    await Task.Delay(1000);
                }
            }
        }
    }
}

