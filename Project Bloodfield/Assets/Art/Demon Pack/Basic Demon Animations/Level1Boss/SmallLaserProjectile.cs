using UnityEngine;

public class SmallLaserProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float damage = 5f;
    [SerializeField]
    private float maxLifetime = 4f;

    private float currentLifetime;
    private Vector2 direction;

    public void Launch(Vector2 target)
    {
        direction = (target - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        if (currentLifetime >= maxLifetime)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += (Vector3)direction * speed * Time.deltaTime;
        currentLifetime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
