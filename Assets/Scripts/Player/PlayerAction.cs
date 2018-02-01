using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerAction : MonoBehaviour {

    private PlayerInventory playerInventory;
    private PlayerAnimator playerAnimator;

    private void Start() {
        playerInventory = GetComponent<PlayerInventory>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if (playerInventory.rightHand.name == "Sword") {
                playerAnimator.animator.SetTrigger("Swing");
            }
        }

        playerAnimator.animator.SetBool("Blocking", Input.GetButton("Fire2") && playerInventory.leftHand.name == "Shield");
    }
}
