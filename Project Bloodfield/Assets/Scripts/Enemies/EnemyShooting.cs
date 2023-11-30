using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;
    public float shootInterval = 3f;
    private float timeSinceLastShot = 0f;
    public LayerMask projectileLayer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        // Ensure the player and projectilePrefab are set
        if (player == null || projectilePrefab == null)
        {
            Debug.LogError("Player or Projectile Prefab not assigned!");
            return;
        }

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Check if it's time to shoot
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval && distanceToPlayer < 10f) // You can adjust the shooting distance as needed
        {
            ShootProjectile();
            timeSinceLastShot = 0f; // Reset the timer
        }
    }

    void ShootProjectile()
    {
        // Instantiate a projectile and set its position and rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        projectile.layer = gameObject.layer;

        // Calculate the direction from the enemy to the player
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Set the projectile's velocity (speed)
        float projectileSpeed = 10f; // You can adjust the projectile speed as needed
        float projectileDistance = 5f; // You can adjust the projectile distance as needed
        Vector3 targetPosition = transform.position + direction * projectileDistance;
        StartCoroutine(MoveProjectile(projectile.transform, targetPosition, projectileSpeed));

        System.Collections.IEnumerator MoveProjectile(Transform projectileTransform, Vector3 targetPosition, float speed)
        {
            while (Vector3.Distance(projectileTransform.position, targetPosition) > 0.1f)
            {
                projectileTransform.position = Vector3.MoveTowards(projectileTransform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Destroy the projectile when it reaches the target
            Destroy(projectileTransform.gameObject);
        }
    }
}