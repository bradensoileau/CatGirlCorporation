using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject laserPrefab;
    public float shootInterval = 10f;
    private float timeSinceLastShot = 0f;
    public float maintainDistance = 10f;
    public float moveSpeed = 5f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player == null || laserPrefab == null)
        {
            Debug.LogError("Player or Laser Prefab not assigned!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < maintainDistance)
        {
            Vector3 directionAwayFromPlayer = transform.position - player.transform.position;
            transform.position += directionAwayFromPlayer.normalized * moveSpeed * Time.deltaTime;
        }

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootInterval && distanceToPlayer >= maintainDistance)
        {
            ShootLaser();
            timeSinceLastShot = 0f;
        }
    }

    void ShootLaser()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        Vector3 spawnPosition = transform.position + directionToPlayer * 1.0f; // Adjust this offset as needed

        GameObject laserInstance = Instantiate(laserPrefab, spawnPosition, lookRotation);

        // Launch the laser towards the player
        LaserProjectile laserProjectile = laserInstance.GetComponent<LaserProjectile>();
        if (laserProjectile != null)
        {
            laserProjectile.Launch(player.transform.position);
        }
    }
}
