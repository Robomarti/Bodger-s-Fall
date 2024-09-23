using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObstacleMovement : ObstacleMovement {
    [SerializeField] private float[] possibleTimesBeforeSidewaysMovement;
    
    private float timeBeforeLeftMovement;
    private float timer;

    protected override void Start() {
        obstacleRigidbody.velocity = Vector2.up * obstacleSpeed;
        timeBeforeLeftMovement =
            possibleTimesBeforeSidewaysMovement[Random.Range(0, possibleTimesBeforeSidewaysMovement.Length)];
    }
    
    private void Update() {
        timer += Time.deltaTime;

        if (timer >= timeBeforeLeftMovement) {
            obstacleRigidbody.velocity = Vector2.left * obstacleSpeed;
        }
    }
}
