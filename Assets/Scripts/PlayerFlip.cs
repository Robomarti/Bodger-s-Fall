using UnityEngine;

// made with https://www.youtube.com/watch?v=D-oQFZgBQE0
[RequireComponent(typeof(InputController))]
public class PlayerFlip : MonoBehaviour {
    [SerializeField] private InputController playerController;
    
    private float horizontalMovement;
    private bool isFacingRight;

    private void Start() {
        isFacingRight = true;
    }
    
    private void Update() {
        horizontalMovement = playerController.RetrieveMovementInput();

        if ((horizontalMovement < 0 && isFacingRight) || (horizontalMovement > 0 && !isFacingRight)) {
            isFacingRight = !isFacingRight;
            transform.Rotate(0,180,0);
        }
    }
}
