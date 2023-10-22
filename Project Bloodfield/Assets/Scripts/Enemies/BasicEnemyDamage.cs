using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();

            if(playerHealth != null)
            {
                 playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
