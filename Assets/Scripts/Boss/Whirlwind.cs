using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Whirlwind : MonoBehaviour {

    private Vector3 initialPosition;
    private Vector3 midPoint;
    private Vector3 playerPosition;

    private float t = 0;

    [SerializeField]
    private float speed = 0.006f;
    [SerializeField]
    private float curveOffset = 15;

    private bool waitingForDestroy = false;

    private void Start() {
        initialPosition = transform.position;
        
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        transform.LookAt(playerPosition);

        midPoint = (playerPosition + initialPosition) / 2;

        bool negative = RandomUtility.RandomBool();
        Vector3 direction = negative ? -transform.right : transform.right;

        midPoint += direction * curveOffset;

        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = midPoint;
    }

    private void Update() {
        transform.position = Vector3Utility.QuadraticLerp(initialPosition, midPoint, playerPosition, t += speed);

        if (t >= 1 && !waitingForDestroy) {
            Destroy(gameObject, 5);
            waitingForDestroy = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerHealth.heartPoints -= 2; // Why is this static?
        }
    }
}
