using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpHeight;

    private bool grounded;

    private Rigidbody rb;
    private Transform mainCamera;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    private void Update() {
        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(Input.GetAxis("Vertical") * movementSpeed, rb.velocity.y, -(Input.GetAxis("Horizontal") * movementSpeed)), Time.deltaTime * 50);
        
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
