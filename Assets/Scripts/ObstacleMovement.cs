using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField] protected Rigidbody2D obstacleRigidbody;
    [SerializeField] protected float obstacleSpeed;
    
    protected virtual void Start() {
        obstacleRigidbody.velocity = Vector2.up * obstacleSpeed;
    }
}
