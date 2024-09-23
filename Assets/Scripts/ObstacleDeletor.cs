using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class ObstacleDeletor : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D hitCollider) {
        if (hitCollider.gameObject.CompareTag("Obstacle") || hitCollider.gameObject.CompareTag("Cloud")) {
            Destroy(hitCollider.gameObject);
        }
    }
}
