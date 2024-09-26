using System.Collections;
using UnityEngine;

// made with https://www.youtube.com/watch?v=vClEQ1GqMPw
public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] protected float obstacleSpawnInterval;
    public Spawnables[] obstaclePrefabs;
    [SerializeField] protected SpawnLocations[] spawnLocations;

    private float timeUntilObstacleSpawn;
    protected GameObject obstacleToSpawn;
    private GameObject spawnedObstacle;
    private Rigidbody2D spawnedObstacleRigidBody;

    private int spawnChances;
    private int spawnChanceCounter;
    
    protected SpawnLocations nextSpawnLocation;

    private void Start() {
        timeUntilObstacleSpawn = obstacleSpawnInterval;
        CountSpawnChances();
        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnLocations[0].spawnPoint.position, Quaternion.identity);
        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnLocations[1].spawnPoint.position, Quaternion.identity);
        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnLocations[2].spawnPoint.position, Quaternion.identity);
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

    protected virtual IEnumerator SpawnObstacle() {
        SetObstacleToSpawn();
        nextSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
        nextSpawnLocation.spawnLocationWarningSign.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        nextSpawnLocation.spawnLocationWarningSign.SetActive(false);
        Instantiate(obstacleToSpawn, nextSpawnLocation.spawnPoint.position, Quaternion.identity);
    }

    protected void SetObstacleToSpawn() {
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
