using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    public GameObject player;

    private Camera cam;
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        cam = Camera.main;
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().player = player;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;
        Vector2 minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));

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


