using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float accelerationSpeed = 50;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float rotationSpeed;

    private bool grounded;

    private Rigidbody rb;
    private Transform mainCamera;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    private void Update() {
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 velocity = new Vector3(horizontal, rb.velocity.y, vertical);

        rb.velocity = Vector3.Lerp(rb.velocity, velocity, accelerationSpeed * Time.deltaTime);

        float yRotation = Mathf.MoveTowards(transform.rotation.y, mainCamera.rotation.y, rotationSpeed * Time.deltaTime);
        transform.rotation = new Quaternion(transform.rotation.x, yRotation, transform.rotation.z, transform.rotation.w);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate() {
        RaycastHit hit;

        Vector3 start = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2 + 0.1f, transform.position.z);
        Vector3 end = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2 - 0.1f, transform.position.z);

        grounded = Physics.Raycast(start, end, out hit);
    }
}
