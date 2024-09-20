using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class BodgerCatchingEvent : MonoBehaviour {
    [SerializeField] private UnityEvent<Transform> inBodgersRangeEvent;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            inBodgersRangeEvent.Invoke(transform);
        }
    }
}
