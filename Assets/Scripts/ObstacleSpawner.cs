using System.Collections;
using UnityEngine;

// made with https://www.youtube.com/watch?v=vClEQ1GqMPw
public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private float obstacleSpawnInterval;
    public Spawnables[] obstaclePrefabs;
    [SerializeField] private SpawnLocations[] spawnLocations;

    private float timeUntilObstacleSpawn;
    private GameObject obstacleToSpawn;
    private GameObject spawnedObstacle;
    private Rigidbody2D spawnedObstacleRigidBody;

    private int spawnChances;
    private int spawnChanceCounter;
    
    private SpawnLocations nextSpawnLocation;

    private void Start() {
        timeUntilObstacleSpawn = 0;
        CountSpawnChances();
    }
    
    private void Update() {
        SpawnLoop();
    }

    private void SpawnLoop() {
        timeUntilObstacleSpawn -= Time.deltaTime;

        if (timeUntilObstacleSpawn <= 0) {
            StartCoroutine(SpawnObstacle());;
            timeUntilObstacleSpawn = obstacleSpawnInterval;
        }
    }

    private IEnumerator SpawnObstacle() {
        SetObstacleToSpawn();
        nextSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
        nextSpawnLocation.spawnLocationWarningSign.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        nextSpawnLocation.spawnLocationWarningSign.SetActive(false);
        Instantiate(obstacleToSpawn, nextSpawnLocation.spawnPoint.position, Quaternion.identity);
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

    [System.Serializable]
    public struct Spawnables {
        public GameObject spawnablePrefab;
        public int spawnChance;
    }
    
    [System.Serializable]
    public struct SpawnLocations {
        public Transform spawnPoint;
        public GameObject spawnLocationWarningSign;
    }
}
