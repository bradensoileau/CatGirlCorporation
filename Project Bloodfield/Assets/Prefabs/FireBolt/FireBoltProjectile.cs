using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolt : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float spellDamage = 10f;
    [SerializeField]
    public float maxLifetime = 6f;

    // Controls the life span of the spell
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

            // Move the projectile in the specified direction
            transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroyed && other.CompareTag("Enemy"))
        {
            // Handle collision with an enemy
            // You can deal damage or apply other effects here.
            // For example, you can access the EnemyStats component on the enemy GameObject and call TakeDamage.
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(spellDamage);
            }

            // Destroy the projectile
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
