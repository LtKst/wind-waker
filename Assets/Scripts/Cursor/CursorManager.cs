using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CursorManager : MonoBehaviour {

    [SerializeField]
    private CursorLockMode lockMode;
    public CursorLockMode LockMode {
        get {
            return lockMode;
        }
        set {
            lockMode = value;
            UpdateLockState();
        }
    }

    private void Start() {
        EventManager.StartListening("OnPauseChange", OnPauseChange);

        UpdateLockState();
    }

    private void OnPauseChange() {
        if (Pause.Paused) {
            lockMode = CursorLockMode.None;
        }
        else {
            lockMode = CursorLockMode.Locked;
        }

        UpdateLockState();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            UpdateLockState();
        }
    }

    private void UpdateLockState() {
        Cursor.lockState = lockMode;
    }
}
