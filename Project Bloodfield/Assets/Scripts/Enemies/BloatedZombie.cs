using UnityEngine;

public class EnemySlimeController : MonoBehaviour
{
    public GameObject player;
    public GameObject slimeBallPrefab;
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
        if (player == null || slimeBallPrefab == null)
        {
            Debug.LogError("Player or Slime Ball Prefab not assigned!");
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
            ShootSlimeBall();
            timeSinceLastShot = 0f;
        }
    }

    void ShootSlimeBall()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        Vector3 spawnPosition = transform.position + directionToPlayer * 1.0f;

        GameObject slimeBallInstance = Instantiate(slimeBallPrefab, spawnPosition, lookRotation);

        SlimeBall slimeBallScript = slimeBallInstance.GetComponent<SlimeBall>();
        if (slimeBallScript != null)
        {
            slimeBallScript.Launch(player.transform.position);
        }
    }
}
