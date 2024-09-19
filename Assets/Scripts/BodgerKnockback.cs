using UnityEngine;
using UnityEngine.Events;

public class BodgerKnockback : MonoBehaviour {
    [SerializeField] private UnityEvent knockPlayerBackEvent;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            knockPlayerBackEvent.Invoke();
        }
    }
}
