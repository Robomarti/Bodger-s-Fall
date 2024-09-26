using System.Collections;
using UnityEngine;

public class BackgroundGraphicsManager : ObstacleSpawner {
    protected override IEnumerator SpawnObstacle() {
        SetObstacleToSpawn();
        nextSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
        Instantiate(obstacleToSpawn, nextSpawnLocation.spawnPoint.position, Quaternion.identity);
        yield return null;
    } 
}
