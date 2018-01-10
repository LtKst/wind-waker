using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CameraController : MonoBehaviour {

    private void Update() {
        transform.LookAt(GameObject.FindWithTag("Player").transform);
    }
}
