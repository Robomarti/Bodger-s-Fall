using UnityEngine;

// From https://github.com/Matthew-J-Spencer/Ultimate-2D-Controller
// and https://www.youtube.com/watch?v=lcw6nuc2uaU
[RequireComponent(typeof(Rigidbody2D), typeof(InputController))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputController playerController;
    [SerializeField] private float sidewaysMovementSpeed;
    [SerializeField] private float downwardsDivingSpeed;
    [SerializeField] private float sidewaysDivingSpeed;
    [SerializeField] private float upwardsFlyingSpeed;
    [SerializeField] private float floatingHeight;
    [SerializeField] private float maximumAcceleration;

    [SerializeField] private float maximumDivingTime;
    [SerializeField] private byte maximumDivingTries;

    [SerializeField] private float peakStopTime;

    private Rigidbody2D playerRigidbody;
    private Vector2 movementDirection;
    private float desiredPlayerVelocityX;
    private Vector2 playerVelocity;
    private bool isDiving;

    private float divingTimer;
    private byte divingCount;

    private float peakStopTimer;
    
    [SerializeField] private Vector2 bodgerStruggleHitDirection;
    
    private void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>();
        divingTimer = maximumDivingTime;
        divingCount = 0;
        peakStopTimer = peakStopTime;
    }

    private void Update() {
        movementDirection.x = playerController.RetrieveMovementInput();
        desiredPlayerVelocityX = movementDirection.x * sidewaysMovementSpeed;
        isDiving = playerController.RetrieveHoldGlideInput();

        if (playerController.RetrieveLetGoGlideInput()) {
            divingCount += 1;
        }
    }
    
    private void FixedUpdate() {
        playerVelocity = playerRigidbody.velocity;

        MovePlayer();
        Glide();

        if (bodgerStruggleHitDirection.magnitude > 0f) {
            bodgerStruggleHitDirection *= 1 - Time.fixedDeltaTime;
            playerVelocity += bodgerStruggleHitDirection;
        }
        
        if (transform.position.y >= floatingHeight) {
            playerVelocity.y = Mathf.Min(playerVelocity.y, 0f);
            divingTimer = maximumDivingTime;
            divingCount = 0;
            peakStopTimer = peakStopTime;
        }

        playerRigidbody.velocity = playerVelocity;
    }

    private void MovePlayer() {
        playerVelocity.x = Mathf.MoveTowards(playerVelocity.x, desiredPlayerVelocityX, maximumAcceleration * Time.deltaTime);
    }

    private void Glide() {
        if (isDiving && divingTimer >= 0 && divingCount < maximumDivingTries) {
            divingTimer -= Time.deltaTime;
            playerVelocity.y = Mathf.Lerp(-downwardsDivingSpeed, -sidewaysDivingSpeed, Mathf.Abs(playerVelocity.x));
        }
        else if (peakStopTimer >= 0) {
            playerVelocity.y = 0;
            peakStopTimer -= Time.deltaTime;
        }
        else {
            playerVelocity.y = upwardsFlyingSpeed;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!(collision.gameObject.CompareTag("BodgerStruggle"))) return;
        divingCount += 1;
        bodgerStruggleHitDirection = new Vector2(0,5);
    }
}
