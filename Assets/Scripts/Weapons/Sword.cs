using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Sword : MonoBehaviour {

    private bool swinging = false;

    private void Start() {
        EventManager.StartListening("OnSwingStart", OnSwingStart);
        EventManager.StartListening("OnSwingEnd", OnSwingEnd);
    }

    void OnSwingStart() {
        swinging = true;
    }

    void OnSwingEnd() {
        swinging = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (swinging) {
            print(other.name);
        }
    }
}
