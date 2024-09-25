using UnityEngine;

// From https://github.com/Matthew-J-Spencer/Ultimate-2D-Controller
// and https://www.youtube.com/watch?v=lcw6nuc2uaU
[RequireComponent(typeof(Rigidbody2D), typeof(InputController))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputController playerController;
    [SerializeField] private float sidewaysMovementSpeed;
    [SerializeField] private float downwardsDivingSpeed;
    [SerializeField] private float maximumAcceleration;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackDeceleration;
    
    // Flying bounds
    [SerializeField] private float PlayerHeightOffset;
    [SerializeField] private float maximumFlyingHeight;
    [SerializeField] private float minimumFlyingHeight;
    [SerializeField] private float PlayerWidthOffset;
    [SerializeField] private float maximumHorizontalPosition;
    [SerializeField] private float minimumHorizontalPosition;

    private Rigidbody2D playerRigidbody;
    private Vector2 movementDirection;
    private float desiredPlayerVelocityX;
    private Vector2 playerVelocity;
    
    private float currentKnockback;
    
    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movementDirection.x = playerController.RetrieveMovementInput();
        desiredPlayerVelocityX = movementDirection.x * sidewaysMovementSpeed;
    }
    
    private void FixedUpdate() {
        playerVelocity = playerRigidbody.velocity;

        MovePlayer();
        MoveDownwards();
        CheckBounds();

        playerRigidbody.velocity = playerVelocity;
    }

    private void MovePlayer() {
        playerVelocity.x = Mathf.MoveTowards(playerVelocity.x, desiredPlayerVelocityX, maximumAcceleration * Time.fixedDeltaTime);
    }

    private void MoveDownwards() {
        if (currentKnockback <= 0) {
            currentKnockback = 0;
        }
        else {
            currentKnockback -= Time.fixedDeltaTime * knockbackDeceleration;
        }

        playerVelocity.y = -downwardsDivingSpeed + currentKnockback;
    }

    private void CheckBounds() {
        // Upper bounds
        if (transform.position.y >= maximumFlyingHeight - PlayerHeightOffset + 1) {
            playerVelocity.y = -1f;
        }
        else if (transform.position.y > maximumFlyingHeight - PlayerHeightOffset) {
            playerVelocity.y = Mathf.Min(playerVelocity.y, 0f);
        }
        
        // Lower bounds
        if (transform.position.y <= minimumFlyingHeight + PlayerHeightOffset - 1) {
            playerVelocity.y = 1f;
        }
        else if (transform.position.y < minimumFlyingHeight + PlayerHeightOffset) {
            playerVelocity.y = Mathf.Max(playerVelocity.y, 0f);
        }
        
        // Right bounds
        if (transform.position.x >= maximumHorizontalPosition - PlayerWidthOffset + 1) {
            playerVelocity.x = -1f;
        }
        else if (transform.position.x > maximumHorizontalPosition - PlayerWidthOffset) {
            playerVelocity.x = Mathf.Min(playerVelocity.x, 0f);
        }
        
        // Left bounds
        if (transform.position.x <= minimumHorizontalPosition + PlayerWidthOffset - 1) {
            playerVelocity.x = 1f;
        }
        else if (transform.position.x < minimumHorizontalPosition + PlayerWidthOffset) {
            playerVelocity.x = Mathf.Max(playerVelocity.x, 0f);
        }
    }

    public void ObstacleHitPlayerEvent() {
        currentKnockback = knockbackForce; 
    }
}
