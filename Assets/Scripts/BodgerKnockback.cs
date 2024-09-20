using UnityEngine;
using UnityEngine.Events;

public class BodgerKnockback : MonoBehaviour {
    [SerializeField] private UnityEvent stopPlayerGlideEvent;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            stopPlayerGlideEvent.Invoke();
        }
    }
}
