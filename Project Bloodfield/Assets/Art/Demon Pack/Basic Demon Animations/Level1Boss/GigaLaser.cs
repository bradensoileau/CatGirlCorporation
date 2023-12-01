using UnityEngine;

public class GigaLaserProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; // Speed of the Giga Laser
    [SerializeField]
    private float damage = 50f; // High damage value for the Giga Laser
    [SerializeField]
    private float maxLifetime = 6f; // Lifetime of the Giga Laser

    private float currentLifetime;
    private bool isDestroyed = false;

    private Vector2 direction; // Direction of movement

    public void Launch(Vector2 target)
    {
        // Calculate the direction towards the target
        direction = (target - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        if (!isDestroyed)
        {
            // Update the lifetime of the laser
            currentLifetime += Time.deltaTime;
            if (currentLifetime >= maxLifetime)
            {
                Destroy(gameObject);
                isDestroyed = true;
                return;
            }

            // Move the laser towards its direction
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroyed && other.CompareTag("Player")) // Check if the laser hits the player
        {
            // Apply damage to the player
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            // Destroy the laser
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
