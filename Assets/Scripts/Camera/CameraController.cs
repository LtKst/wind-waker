using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CameraController : MonoBehaviour {

    [SerializeField]
    private bool autoTargetPlayer;
    [SerializeField]
    private Transform cameraTarget;
    private float x = 0.0f;
    private float y = 0.0f;

    private int mouseXSpeedMod = 5;
    private int mouseYSpeedMod = 5;

    [SerializeField]
    private int ZoomRate = 20;
    [SerializeField]
    private float distance = 3f;
    private float desireDistance;
    private float correctedDistance;
    private float currentDistance;

    [SerializeField]
    private float cameraTargetHeight = 1.0f;
    
    private void Start() {
        Vector3 Angles = transform.eulerAngles;
        x = Angles.x;
        y = Angles.y;
        currentDistance = distance;
        desireDistance = distance;
        correctedDistance = distance;

        if (autoTargetPlayer) {
            cameraTarget = GameObject.FindWithTag("Player").transform;
        }
    }
    
    private void LateUpdate() {
        if (!Pause.Paused) {
            x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
            y += Input.GetAxis("Mouse Y") * mouseYSpeedMod;

            y = ClampAngle(y, -15, 25);
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            correctedDistance = desireDistance;

            Vector3 position = cameraTarget.position - (rotation * Vector3.forward * desireDistance);

            RaycastHit collisionHit;
            Vector3 cameraTargetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y + cameraTargetHeight, cameraTarget.position.z);

            bool isCorrected = false;
            if (Physics.Linecast(cameraTargetPosition, position, out collisionHit)) {
                if (!collisionHit.collider.isTrigger) {
                    position = collisionHit.point;
                    correctedDistance = Vector3.Distance(cameraTargetPosition, position);
                    isCorrected = true;
                }
            }

            currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * ZoomRate) : correctedDistance;

            position = cameraTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -cameraTargetHeight, 0));

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    private static float ClampAngle(float angle, float min, float max) {
        if (angle < -360) {
            angle += 360;
        }
        if (angle > 360) {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
