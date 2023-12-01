using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; // Adjust speed as needed for the laser
    [SerializeField]
    private float damage = 15f; // Adjust damage as needed
    [SerializeField]
    private float maxLifetime = 6f; // Lasers usually have a shorter lifespan

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
        if (!isDestroyed && other.CompareTag("Player")) // Checking for the Player tag
        {
            // Handle collision with the player
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
