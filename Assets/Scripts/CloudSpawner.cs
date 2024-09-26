using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private float obstacleSpawnInterval;
    [SerializeField] private Spawnables[] obstaclePrefabs;
    [SerializeField] private Transform[] spawnLocations;

    private float timeUntilObstacleSpawn;
    private GameObject obstacleToSpawn;

    private int spawnChances;
    private int spawnChanceCounter;

    private Transform nextSpawnLocation;

    private void Start() {
        timeUntilObstacleSpawn = obstacleSpawnInterval;
        CountSpawnChances();

        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnLocations[0].position, Quaternion.identity);
        
        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnLocations[1].position, Quaternion.identity);
        
        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnLocations[2].position, Quaternion.identity);
    }
    
    private void Update() {
        SpawnLoop();
    }

    private void SpawnLoop() {
        timeUntilObstacleSpawn -= Time.deltaTime;

        if (timeUntilObstacleSpawn <= 0) {
            SetObstacleToSpawn();
            nextSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
            Instantiate(obstacleToSpawn, nextSpawnLocation.position, Quaternion.identity);
            timeUntilObstacleSpawn = obstacleSpawnInterval;
        }
    }

    private void SetObstacleToSpawn() {
        spawnChanceCounter = Random.Range(0, spawnChances);

        foreach (Spawnables spawnable in obstaclePrefabs) {
            spawnChanceCounter -= spawnable.spawnChance;
            if (spawnChanceCounter <= 0) {
                obstacleToSpawn = spawnable.spawnablePrefab;
                return;
            }
        }
    }

    private void CountSpawnChances() {
        foreach (Spawnables spawnable in obstaclePrefabs) {
            spawnChances += spawnable.spawnChance;
        }
    }
 
}
