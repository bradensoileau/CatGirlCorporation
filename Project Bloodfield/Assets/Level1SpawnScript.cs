using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnPoint
    {
        public Transform point;
    }

    [SerializeField]
    private GameObject[] enemyPrefabs; // Assign your enemy prefabs in the Inspector
    [SerializeField]
    private GameObject bossPrefab; // Assign your boss prefab in the Inspector
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int numberOfSpawnPoints = 50;
    [SerializeField]
    private float spacingBetweenSpawnPoints = 5f;
    [SerializeField]
    private int currentWaveIndex = 0;
    [SerializeField]
    private float timeBetweenWaves = 5f;

    [SerializeField]
    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    private float timeSinceLastWave;
    private Camera cam;
    private int totalSpawnedEnemies = 0; // Counter for spawned enemies
    [SerializeField]
    private int maxSpawnedEnemies = 100; // Maximum number of enemies to spawn

    //boss stuff
    private int defeatedEnemyCount = 0; // Counter for defeated enemies
    private bool bossSpawned = false; // Flag to ensure boss is spawned only once

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = Camera.main;
        GenerateSpawnPoints();
    }

    private void Update()
    {
        timeSinceLastWave += Time.deltaTime;

        if (currentWaveIndex < 5 && timeSinceLastWave >= timeBetweenWaves)
        {
            StartCoroutine(SpawnWave());
            timeSinceLastWave = 0f;
        }

        // Check if it's time to spawn the boss
        if (!bossSpawned && defeatedEnemyCount >= 50)
        {
            SpawnBoss();
            bossSpawned = true;
        }
    }

    private void GenerateSpawnPoints()
    {
        GameObject spawnPointsParent = new GameObject("SpawnPointsParent");

        for (int spawnPointIndex = 0; spawnPointIndex < numberOfSpawnPoints; spawnPointIndex++)
        {
            Vector3 spawnPosition = new Vector3(spawnPointIndex * spacingBetweenSpawnPoints, 0f, 0f);
            GameObject spawnPointObject = new GameObject("SpawnPoint_" + spawnPointIndex);
            spawnPointObject.transform.position = spawnPosition;
            spawnPointObject.transform.parent = spawnPointsParent.transform;

            SpawnPoint spawnPoint = new SpawnPoint();
            spawnPoint.point = spawnPointObject.transform;

            spawnPoints.Add(spawnPoint);
        }
    }

    private IEnumerator SpawnWave()
    {
        int enemiesToSpawn = 8; // Number of enemies to spawn in each iteration

        while (enemiesToSpawn > 0 && totalSpawnedEnemies < maxSpawnedEnemies)
        {
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                SpawnEnemy(spawnPoint.point);
                enemiesToSpawn--;
                totalSpawnedEnemies++;

                if (enemiesToSpawn <= 0 || totalSpawnedEnemies >= maxSpawnedEnemies)
                    break;
            }

            yield return new WaitForSeconds(Random.Range(1f, 4f)); // Randomize spawn delay between 1-4 seconds
        }
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned.");
            return;
        }

        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPosition = FindRandomSpawnPositionAwayFromPlayer(spawnPoint.position);
        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, spawnPoint.rotation);
    }

    private Vector3 FindRandomSpawnPositionAwayFromPlayer(Vector3 spawnPoint)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 directionToPlayer = spawnPoint - playerPosition;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer < 10f) // Adjust the distance as needed
        {
            // If the spawn point is too close to the player, find a new position away from the player
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 newPosition = (Vector2)player.transform.position + randomDirection * 10f; // 10 units away from the player
            return new Vector3(newPosition.x, newPosition.y, spawnPoint.z);
        }

        return spawnPoint;
    }

    private void SpawnBoss()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomSpawnPointIndex].point;
        Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity); // Spawn the boss
    }

    // Method to be called when an enemy is defeated
    public void OnEnemyDefeated()
    {
        defeatedEnemyCount++;
    }
}
