using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {

    private PlayerAnimator playerAnimation;
    private Rigidbody rb;
    private CapsuleCollider col;
    private Transform mainCamera;

    [SerializeField]
    private float walkSpeed = 2;
    [SerializeField]
    private float runSpeed = 5;
    [SerializeField]
    private float crawlMultiplier = 0.5f;
    [SerializeField]
    private float accelerationSpeed = 50;
    [SerializeField]
    private float rotationSpeed = 5;
    [SerializeField]
    private float jumpForce = 5;

    private bool crouching;
    private bool crawling;
    private bool grounded;

    private void Start() {
        playerAnimation = GetComponent<PlayerAnimator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        mainCamera = Camera.main.transform;
    }

    private void Update() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        crouching = Input.GetKey(KeyCode.LeftControl);

        if (horizontal != 0 || vertical != 0) {
            if (Input.GetKey(KeyCode.LeftControl)) {
                crawling = true;
            }

            float speed = Input.GetKey(KeyCode.LeftShift) ? walkSpeed : runSpeed;

            if (crawling) {
                speed *= crawlMultiplier;
            }

            // Calculate and set the velocity
            Vector3 forward = transform.forward * speed;
            forward.y = rb.velocity.y;

            rb.velocity = Vector3.Slerp(rb.velocity, forward, accelerationSpeed * Time.deltaTime);

            // Calculate and set the rotation
            Vector3 targetDirection = mainCamera.forward * vertical + mainCamera.right * horizontal;
            targetDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else {
            // Slow down when not recieving input
            Vector3 zero = Vector3.zero;
            zero.y = rb.velocity.y;

            rb.velocity = Vector3.Slerp(rb.velocity, zero, accelerationSpeed * Time.deltaTime);

            if (!Input.GetKey(KeyCode.LeftControl)) {
                crawling = false;
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !crouching) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        playerAnimation.SetBaseValues(rb.velocity.magnitude, crouching, crawling, grounded);
    }

    private void FixedUpdate() {
        // Check if the player is grounded
        Vector3 start = new Vector3(transform.position.x, transform.position.y - col.bounds.size.y / 2 + 0.1f + col.center.y, transform.position.z);

        RaycastHit hit;

        grounded = Physics.Raycast(start, Vector3.down, out hit, 0.2f) && hit.collider.tag != "Player";
    }
}
