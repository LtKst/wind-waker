using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CursorManager : MonoBehaviour {

    [SerializeField]
    private bool lockCursor = false;
    public bool LockCursor {
        get {
            return lockCursor;
        }
        set {
            lockCursor = value;
            UpdateCursor();
        }
    }

    private void Start() {
        UpdateCursor();
    }

    private void UpdateCursor() {
        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
