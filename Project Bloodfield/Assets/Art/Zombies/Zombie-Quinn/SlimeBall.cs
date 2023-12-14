using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float maxLifetime = 6f;
    private float currentLifetime;
    private bool isDestroyed = false;
    private Vector2 direction;

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

            transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroyed && other.CompareTag("Player"))
        {
            // Handle collision with the player (or any target)
            // You can deal damage or apply other effects here.
            // For example, you can access the PlayerStats component on the player GameObject and call TakeDamage.
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            // Destroy the projectile
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
