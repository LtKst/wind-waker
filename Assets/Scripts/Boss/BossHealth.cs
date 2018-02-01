using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class BossHealth : MonoBehaviour {

    [SerializeField]
    private int health = 100;
    public bool isDead;

    private Animator animator;

    [SerializeField]
    private AudioClip takeHitClip;
    private AudioSource audioSource;

    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount) {
        if (!isDead) {
            health -= amount;

            audioSource.PlayOneShot(takeHitClip);

            if (health <= 0) {
                isDead = true;
                animator.SetBool("Dead", true);
            }
            else {
                animator.SetTrigger("TakeHit");
            }
        }
    }
}
