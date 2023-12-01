using UnityEngine;

public class SmallLaserLaunch : MonoBehaviour
{
    public GameObject player;
    public GameObject smallLaserPrefab;
    public float shootInterval = 5f;
    private float timeSinceLastShot = 0f;

    void Update()
    {
        if (player == null || smallLaserPrefab == null)
        {
            Debug.LogError("Player or Small Laser Prefab not assigned!");
            return;
        }

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootInterval)
        {
            ShootSmallLaser();
            timeSinceLastShot = 0f;
        }
    }

    void ShootSmallLaser()
    {
        GameObject laserInstance = Instantiate(smallLaserPrefab, transform.position, Quaternion.identity);
        SmallLaserProjectile smallLaserProjectile = laserInstance.GetComponent<SmallLaserProjectile>();
        if (smallLaserProjectile != null)
        {
            smallLaserProjectile.Launch(player.transform.position);
        }
    }
}
