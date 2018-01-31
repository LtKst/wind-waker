using UnityEngine;

/// <summary>
/// A script for pausing or unpausing the game
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

        EventManager.TriggerEvent("OnPauseChange");
    }
    
    public static void UnPauseGame() {
        paused = false;
        Time.timeScale = 1;

        EventManager.TriggerEvent("OnPauseChange");
    }
}
