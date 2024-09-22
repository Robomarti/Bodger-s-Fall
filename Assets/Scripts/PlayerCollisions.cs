using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour {
    [SerializeField] private UnityEvent<Transform> inBodgersRangeEvent;
    [SerializeField] private UnityEvent playerHitObstacleEvent;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Bodger")) {
            inBodgersRangeEvent.Invoke(transform);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D hitCollider) {
        if (hitCollider.gameObject.CompareTag("Obstacle")) {
            playerHitObstacleEvent.Invoke();
        }
    }
}
