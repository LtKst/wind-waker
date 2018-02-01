using UnityEngine;

/// <summary>
/// Easy access to the player's animator
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour {

    [HideInInspector]
    public Animator animator;

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
    public void SetBaseValues(float velocity, bool crouching, bool crawling, bool grounded) {
        animator.SetFloat("Velocity", velocity);
        animator.SetBool("Crouching", crouching);
        animator.SetBool("Crawling", crawling);
        animator.SetBool("Grounded", grounded);
    }
}
