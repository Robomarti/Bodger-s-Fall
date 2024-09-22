using UnityEngine;

// made with https://www.youtube.com/watch?v=vClEQ1GqMPw
public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float obstacleSpawnInterval;
    [SerializeField] private Transform spawnPoint;

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
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
