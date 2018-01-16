using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Pause : MonoBehaviour {

    private static bool paused;
    public static bool Paused {
        get {
            return paused;
        }
    }

    public static void PauseGame() {
        paused = true;
        Time.timeScale = 0;
    }

    public static void UnPauseGame() {
        paused = false;
        Time.timeScale = 1;
    }
}
