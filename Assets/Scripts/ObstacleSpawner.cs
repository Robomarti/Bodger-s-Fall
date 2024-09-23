using UnityEngine;

// made with https://www.youtube.com/watch?v=vClEQ1GqMPw
public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private float obstacleSpawnInterval;
    [SerializeField] private Transform[] spawnPoints;

    public Spawnables[] obstaclePrefabs;

    private float timeUntilObstacleSpawn;
    private GameObject obstacleToSpawn;
    private GameObject spawnedObstacle;
    private Rigidbody2D spawnedObstacleRigidBody;

    private int spawnChances;
    private int spawnChanceCounter;

    private void Start() {
        timeUntilObstacleSpawn = 1;
        CountSpawnChances();
    }
    
    private void Update() {
        SpawnLoop();
    }

    private void SpawnLoop() {
        timeUntilObstacleSpawn -= Time.deltaTime;

        if (timeUntilObstacleSpawn <= 0) {
            SpawnObstacle();
            timeUntilObstacleSpawn = obstacleSpawnInterval;
        }
    }

    private void SpawnObstacle() {
        SetObstacleToSpawn();
        Instantiate(obstacleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
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
}
