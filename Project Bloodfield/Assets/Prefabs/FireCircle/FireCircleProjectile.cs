using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLaserProjectile : MonoBehaviour
{
    // Laser Variables
    [SerializeField]
    public float speed = 20f; // Increased speed for a laser
    [SerializeField]
    private float laserDamage = 5f; // Damage can be adjusted as needed
    [SerializeField]
    public float maxLifetime = 2f; // Shorter lifetime for a laser

    // Controls the life span of the laser
    private float currentLifetime;
    private bool isDestroyed = false;

    private Vector2 direction; // Store the direction for movement

    public void Launch(Vector2 target)
    {
        direction = (target - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        if (!isDestroyed)
        {
            currentLifetime += Time.deltaTime;
            if (currentLifetime >= maxLifetime)
            {
                Destroy(gameObject);
                isDestroyed = true;
                return;
            }

            // Move the laser in the specified direction
            transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroyed && other.CompareTag("Enemy"))
        {
            // Handle collision with an enemy
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(laserDamage);
            }

            // Destroy the laser
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
