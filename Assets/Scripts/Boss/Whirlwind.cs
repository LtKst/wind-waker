using UnityEngine;

public class Whirlwind : MonoBehaviour {

    private Vector3 initialPosition;
    private Vector3 midPoint;
    private Vector3 playerPosition;

    private float t = 0;

    [SerializeField]
    private float speed = 1f;

    private void Start() {
        initialPosition = transform.position;
        
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        transform.LookAt(playerPosition);

        midPoint = (playerPosition + initialPosition) / 2;
        midPoint += transform.right * 20;
    }

    private void Update() {
        transform.position = Vector3Utility.QuadraticLerp(initialPosition, midPoint, playerPosition, t += speed);

        if (t >= 1) {
            Destroy(gameObject, 5);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            print("Hit player");
        }
    }
}
