using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField] private Rigidbody2D obstacleRigidbody;
    [SerializeField] private float obstacleSpeed;
    
    private void Start() {
        obstacleRigidbody.velocity = Vector2.up * obstacleSpeed;
    }
}
