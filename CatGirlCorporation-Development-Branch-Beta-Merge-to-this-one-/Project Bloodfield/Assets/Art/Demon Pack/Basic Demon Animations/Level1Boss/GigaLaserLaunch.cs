using UnityEngine;

public class GigaLaserLaunch : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public GameObject gigaLaserPrefab; // Assign your Giga Laser prefab here in the inspector
    public float shootInterval = 10f; // Interval for Giga Laser attack
    private float timeSinceLastShot = 0f; // Time since the last shot was fired

    private void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Check if the player and laser prefab are assigned
        if (player == null || gigaLaserPrefab == null)
        {
            Debug.LogError("Player or Giga Laser Prefab not assigned!");
            return;
        }

        // Update the timer
        timeSinceLastShot += Time.deltaTime;

        // Check if it's time to shoot
        if (timeSinceLastShot >= shootInterval)
        {
            ShootGigaLaser();
            timeSinceLastShot = 0f; // Reset the timer
        }
    }

    void ShootGigaLaser()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // Instantiate the Giga Laser prefab
        GameObject laserInstance = Instantiate(gigaLaserPrefab, transform.position, Quaternion.identity);

        // Launch the Giga Laser towards the player
        GigaLaserProjectile gigaLaserProjectile = laserInstance.GetComponent<GigaLaserProjectile>();
        if (gigaLaserProjectile != null)
        {
            gigaLaserProjectile.Launch(player.transform.position);
        }
        else
        {
            Debug.LogError("GigaLaserProjectile component not found on the prefab.");
        }
    }
}
