using UnityEngine;

// made with https://www.youtube.com/watch?v=vClEQ1GqMPw
public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private float obstacleSpawnInterval;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private float timeUntilObstacleSpawn;
    private GameObject obstacleToSpawn;
    private GameObject spawnedObstacle;
    private Rigidbody2D spawnedObstacleRigidBody;

    private void Start() {
        timeUntilObstacleSpawn = obstacleSpawnInterval;
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
        obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Instantiate(obstacleToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
}
