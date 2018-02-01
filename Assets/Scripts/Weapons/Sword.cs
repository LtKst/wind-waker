using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Sword : MonoBehaviour {

    private bool swinging = false;

    [SerializeField]
    private int damage = 7;

    [SerializeField]
    private AudioClip[] attackClips;
    private AudioSource audioSource;


    private void Start() {
        audioSource = GetComponent<AudioSource>();

        EventManager.StartListening("OnSwingStart", OnSwingStart);
        EventManager.StartListening("OnSwingEnd", OnSwingEnd);
    }

    private void OnSwingStart() {
        audioSource.PlayOneShot(attackClips[Random.Range(0, attackClips.Length - 1)]);
        swinging = true;
    }

    private void OnSwingEnd() {
        swinging = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (swinging) {
            if (other.GetComponent<BossHealth>()) {
                other.GetComponent<BossHealth>().TakeDamage(damage);
            }
        }
    }
}
