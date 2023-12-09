using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    /*This class holds information about each spawnpoint, including the transform of the spawnpoint along with the amount of enemies to spawn at that point.
    The 'spawnPoints' list is a list of the spawnpoints, which can be configured in the Unity editor.*/
    [System.Serializable]
    public class SpawnPoint
    {
        public Transform point;
        public int enemiesToSpawn;
    }

    [System.Serializable]
    public class Wave
    {
        public int enemiesPerSpawn;
        public float timeBetweenSpawns;
    }

    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private GameObject bossPrefab;
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
    private int enemiesPerWave = 50;
    
    [SerializeField]
    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField]
    private List<Wave> waves = new List<Wave>();

    private float timeSinceLastWave;
    private Camera cam;

    //This function is called at game start
    private void Start()
    {
        //In order to get the player, we find the tag player labeled on the main character and it gets a reference to the game object.
        player = GameObject.FindWithTag("Player");

        //Gets a reference to the camera game object
        cam = Camera.main;

        //Calls the function that spawns in all the different spawn point locations
        GenerateSpawnPoints();
    }

    //This function is called every frame the game is running
    private void Update()
    {
        timeSinceLastWave += Time.deltaTime;

        if(currentWaveIndex < waves.Count && timeSinceLastWave >= timeBetweenWaves)
        {
            StartCoroutine(SpawnWave());
            timeSinceLastWave = 0f;
        }
    }

    private void GenerateSpawnPoints()
    {
        // Creates a parent game object for all spawn points
        GameObject spawnPointsParent = new GameObject("SpawnPointsParent");

        for (int spawnPointIndex = 0; spawnPointIndex < numberOfSpawnPoints; spawnPointIndex++)
        {
            Vector3 spawnPosition = new Vector3(spawnPointIndex * spacingBetweenSpawnPoints, 0f, 0f);
            GameObject spawnPointObject = new GameObject("SpawnPoint_" + spawnPointIndex);
            spawnPointObject.transform.position = spawnPosition;
            spawnPointObject.transform.parent = spawnPointsParent.transform;

            SpawnPoint spawnPoint = new SpawnPoint();
            spawnPoint.point = spawnPointObject.transform;
            spawnPoint.enemiesToSpawn = enemiesPerWave;

            spawnPoints.Add(spawnPoint);
        }
    }

    IEnumerator SpawnWave()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            int enemiesRemaining = spawnPoint.enemiesToSpawn;

            while (enemiesRemaining > 0)
            {
                SpawnEnemy(spawnPoint.point);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeBetweenSpawns);
                enemiesRemaining--;
            }
        }
    }

    void SpawnEnemy(Transform spawnPoint)
    {
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPoint.position, spawnPoint.rotation);
    }

}