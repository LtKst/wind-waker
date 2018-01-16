using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 5;
    [SerializeField]
    private float accelerationSpeed = 50;
    [SerializeField]
    private float jumpHeight = 200;
    [SerializeField]
    private float rotationSpeed = 5;

    private bool grounded;

    private Rigidbody rb;
    private Collider col;
    private Transform mainCamera;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        mainCamera = Camera.main.transform;
    }

    private void Update() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0 || vertical != 0) {
            // Calculate and set the velocity
            Vector3 forward = transform.forward * movementSpeed;
            forward.y = rb.velocity.y;

            rb.velocity = Vector3.Slerp(rb.velocity, forward, accelerationSpeed * Time.deltaTime);

            // Calculate and set the rotation
            Vector3 facingDirection = mainCamera.forward * vertical + mainCamera.right * horizontal;
            facingDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(facingDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        } else {
            // Slow down when not recieving input
            Vector3 zero = Vector3.zero;
            zero.y = rb.velocity.y;

            rb.velocity = Vector3.Slerp(rb.velocity, zero, accelerationSpeed * Time.deltaTime);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            print("jump");
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate() {
        // Check if the player is grounded
        Vector3 start = new Vector3(transform.position.x, transform.position.y - col.bounds.size.y / 2 + 0.1f, transform.position.z);
        Vector3 end = new Vector3(transform.position.x, transform.position.y - col.bounds.size.y / 2 - 0.1f, transform.position.z);

        grounded = Physics.Raycast(start, end);

        print(grounded);

        // Debug the grounded raycast
        Debug.DrawLine(start, end, Color.red);
    }
}
