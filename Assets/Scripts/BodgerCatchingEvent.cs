using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class BodgerCatchingEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collider2D> onTriggerEnter2DEvent;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            onTriggerEnter2DEvent.Invoke(collision);
        }
    }
}
