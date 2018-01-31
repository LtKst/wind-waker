using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update the player's animator
    /// </summary>
    /// <param name="velocity">The speed of the player</param>
    /// <param name="crouching">Whether the player is crouching or not</param>
    /// <param name="crawling">Whether the player is crawling or not</param>
    /// <param name="grounded">Whether the player is on the ground or not</param>
    public void UpdateAnimator(float velocity, bool crouching, bool crawling, bool grounded) {
        animator.SetFloat("Velocity", velocity);
        animator.SetBool("Crouching", crouching);
        animator.SetBool("Crawling", crawling);
        animator.SetBool("Grounded", grounded);
    }

    /// <summary>
    /// Start the equip animation
    /// </summary>
    public void StartEquipAnimation() {
        animator.SetTrigger("Grab");
    }
}
