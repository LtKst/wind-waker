using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PauseInput : MonoBehaviour {

    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private AudioClip pause;
    [SerializeField]
    private AudioClip unpause;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!Pause.Paused) {
                Pause.PauseGame();
                audioSource.PlayOneShot(pause);
                pauseUI.SetActive(true);
            }
            else {
                Pause.UnPauseGame();
                audioSource.PlayOneShot(unpause);
                pauseUI.SetActive(false);
            }
        }
    }
}
