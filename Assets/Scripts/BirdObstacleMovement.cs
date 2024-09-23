using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObstacleMovement : ObstacleMovement {
    [SerializeField] private float[] possibleTimesBeforeSidewaysMovement;
    
    private float timeBeforeLeftMovement;
    private float timer;

    private bool movesLeft;

    protected override void Start() {
        obstacleRigidbody.velocity = Vector2.up * obstacleSpeed;
        timeBeforeLeftMovement =
            possibleTimesBeforeSidewaysMovement[Random.Range(0, possibleTimesBeforeSidewaysMovement.Length)];
        
        movesLeft = Random.Range(0, 2) == 0;
    }
    
    private void Update() {
        timer += Time.deltaTime;

        if (timer >= timeBeforeLeftMovement) {
            if (movesLeft) {
                obstacleRigidbody.velocity = Vector2.left * obstacleSpeed;
            }
            else {
                obstacleRigidbody.velocity = Vector2.right * obstacleSpeed;
            }
        }
    }
}
