using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerInventory : MonoBehaviour {

    private PlayerAnimator playerAnimator;

    [SerializeField]
    private EquipableItem[] storedItems;

    private EquipableItem equippedItem;
    private EquipableItem unequippedItem;

    [SerializeField]
    private Transform backPivot;

    [HideInInspector]
    public EquipableItem rightHand;
    [HideInInspector]
    public EquipableItem leftHand;

    private void Start() {
        playerAnimator = GetComponent<PlayerAnimator>();

        for (int i = 0; i < storedItems.Length; i++) {
            storedItems[i].Instance.transform.parent = backPivot;
            storedItems[i].Instance.transform.SetPositionAndRotation(backPivot.position, backPivot.rotation);
        }

        EventManager.StartListening("OnGrabAnimationFinished", OnGrabAnimationFinished);
    }

    private void Update() {
        for (int i = 0; i < storedItems.Length; i++) {
            if (Input.GetKeyDown(storedItems[i].equipKeyCode)) {
                if (equippedItem == storedItems[i]) {
                    UnequipItem(storedItems[i]);
                }
                else {
                    EquipItem(storedItems[i]);
                }
            }
        }
    }

    private void EquipItem(EquipableItem item) {
        if (equippedItem != null && equippedItem.equipSlot == item.equipSlot) {
            UnequipItem(equippedItem);
        }

        if (item.equipSlot == EquipableItem.EquipSlot.Right) {
            rightHand = item;
        }
        else if (item.equipSlot == EquipableItem.EquipSlot.Left) {
            leftHand = item;
        }

        playerAnimator.animator.SetTrigger("Grab");

        equippedItem = item;
    }

    private void UnequipItem(EquipableItem item) {
        unequippedItem = item;

        if (item.equipSlot == EquipableItem.EquipSlot.Right) {
            rightHand = null;
        }
        else if (item.equipSlot == EquipableItem.EquipSlot.Left) {
            leftHand = null;
        }

        playerAnimator.animator.SetTrigger("Grab");
    }

    private void OnGrabAnimationFinished() {
        // Equip
        equippedItem.Instance.transform.parent = equippedItem.pivotPoint;
        equippedItem.Instance.transform.SetPositionAndRotation(equippedItem.pivotPoint.position, equippedItem.pivotPoint.rotation);

        // Unequip
        if (unequippedItem != null) {
            unequippedItem.Instance.transform.parent = backPivot;
            unequippedItem.Instance.transform.SetPositionAndRotation(backPivot.position, backPivot.rotation);

            if (equippedItem == unequippedItem) {
                equippedItem = null;
            }

            unequippedItem = null;
        }
    }
}
