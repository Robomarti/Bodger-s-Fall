using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputController))]
public class PlayersCatchingAbility : MonoBehaviour {
    [SerializeField] private InputController playerController;

    private bool triesToCatch;
    
    private void Update() {
        triesToCatch |= playerController.RetrieveCatchInput();
    }

    public void InBodgersRadius(Collider2D collision) {
        if (triesToCatch) {
            triesToCatch = false;
        }
    }
}
