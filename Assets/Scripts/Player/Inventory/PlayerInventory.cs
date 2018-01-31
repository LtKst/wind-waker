using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerInventory : MonoBehaviour {

    private PlayerAnimator playerAnimator;

    [SerializeField]
    private EquipableItem[] backItems;

    private EquipableItem equippedItem;
    private EquipableItem unequippedItem;

    [SerializeField]
    private Transform back;

    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;

    private void Start() {
        playerAnimator = GetComponent<PlayerAnimator>();

        for (int i = 0; i < backItems.Length; i++) {
            backItems[i].Instance.transform.parent = back;
            backItems[i].Instance.transform.SetPositionAndRotation(back.position, back.rotation);
        }

        EventManager.StartListening("OnGrabAnimationFinished", OnGrabAnimationFinished);
    }

    private void Update() {
        for (int i = 0; i < backItems.Length; i++) {
            if (Input.GetKeyDown(backItems[i].equipKeyCode)) {
                if (equippedItem == backItems[i]) {
                    UnequipItem(backItems[i]);
                }
                else {
                    EquipItem(backItems[i]);
                }
            }
        }
    }

    private void EquipItem(EquipableItem item) {
        if (equippedItem != null && equippedItem.equipSlot == item.equipSlot) {
            UnequipItem(equippedItem);
        }

        playerAnimator.StartEquipAnimation();

        equippedItem = item;
    }

    private void UnequipItem(EquipableItem item) {
        unequippedItem = item;

        playerAnimator.StartEquipAnimation();
    }

    private void OnGrabAnimationFinished() {
        // Equip
        if (equippedItem.equipSlot == EquipableItem.EquipSlot.Right) {
            equippedItem.Instance.transform.parent = rightHand;
            equippedItem.Instance.transform.SetPositionAndRotation(rightHand.position, rightHand.rotation);
        }
        else {
            equippedItem.Instance.transform.parent = leftHand;
            equippedItem.Instance.transform.SetPositionAndRotation(leftHand.position, leftHand.rotation);
        }

        // Unequip
        if (unequippedItem != null) {
            unequippedItem.Instance.transform.parent = back;
            unequippedItem.Instance.transform.SetPositionAndRotation(back.position, back.rotation);

            if (equippedItem == unequippedItem) {
                equippedItem = null;
            }

            unequippedItem = null;
        }
    }
}
