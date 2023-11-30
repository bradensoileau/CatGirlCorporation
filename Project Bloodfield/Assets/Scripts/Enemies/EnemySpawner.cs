using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float startingSpawnInterval = 2f;
    public float minimumSpawnInterval = 0.5f;
    public float spawnRateIncreaseInterval = 10f;
    public float spawnRadius = 10f;
    public float minDistanceToPlayer = 5f; //DISTANCE THAT ENEMIES CANNOT SPAWN IN
    public float spawnTimeAdjuster = 0.1f;
    public GameObject player;

    private float spawnInterval;

    private Camera cam;
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        cam = Camera.main;

        spawnInterval = startingSpawnInterval;
        
        StartCoroutine(SpawnEnemies());
        StartCoroutine(IncreaseSpawnRate());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();

            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator IncreaseSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRateIncreaseInterval);
            if(spawnInterval > minimumSpawnInterval)
            {
                spawnInterval -= spawnTimeAdjuster; 
            }
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;
        Vector2 minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));

        //THE BOUNDS WHERE ENEMY CANNOT SPAWN AROUND THE PLAYER
        float minX = player.transform.position.x + minDistanceToPlayer;
        float maxX = player.transform.position.x - minDistanceToPlayer;
        float minY = player.transform.position.y + minDistanceToPlayer;
        float maxY = player.transform.position.y - minDistanceToPlayer;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: //Top
                spawnPosition = new Vector3(Random.Range(minBounds.x, maxBounds.x), maxBounds.y + spawnRadius, 0);
                break;
            case 1: //Bottom
                spawnPosition = new Vector3(Random.Range(minBounds.x, maxBounds.x), maxBounds.y - spawnRadius, 0);
                break;
            case 2: //Left
                spawnPosition = new Vector3(minBounds.x - spawnRadius, Random.Range(minBounds.y, maxBounds.y), 0);
                break;
            case 3: //Right
                spawnPosition = new Vector3(minBounds.x + spawnRadius, Random.Range(minBounds.y, maxBounds.y), 0);
                break;
        }

        return spawnPosition;
    }

}


