using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimator(float velocity, bool crouching, bool grounded) {
        animator.SetFloat("Velocity", velocity);
        animator.SetBool("Crouching", crouching);
        animator.SetBool("Grounded", grounded);
    }
}
