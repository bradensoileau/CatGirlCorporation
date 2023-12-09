using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 1000; // Boss health

    void Start()
    {
        // Any initialization logic if needed
    }

    public void TakeDamage(int damage)
    {
        // Reduce health by the damage amount
        health -= damage;

        // Check if health drops below zero and handle boss defeat
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Log the defeat and handle any additional logic for boss death
        Debug.Log("Boss is defeated!");
        // Additional logic for boss death (e.g., animations, game state changes) can be added here.

        // Optional: Destroy the boss object or disable it
         Destroy(gameObject);
    }

    // Additional methods related to boss behavior can be added here
}
