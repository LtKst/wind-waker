using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerInventory : MonoBehaviour {

    private PlayerAnimator playerAnimator;

    [SerializeField]
    private EquipableItem[] storedItems;
    
    private EquipableItem unequippedItem;

    [SerializeField]
    private Transform backPivot;

    [HideInInspector]
    public EquipableItem rightHand = new EquipableItem();
    [HideInInspector]
    public EquipableItem leftHand = new EquipableItem();

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
                if (storedItems[i] == rightHand) {
                    UnequipItem(storedItems[i]);
                } else if (storedItems[i] == leftHand) {
                    UnequipItem(storedItems[i]);
                }
                else {
                    EquipItem(storedItems[i]);
                }
            }
        }
    }

    private void EquipItem(EquipableItem item) {
        if (item.equipSlot == EquipableItem.EquipSlot.Right) {
            rightHand = item;
        }
        else if (item.equipSlot == EquipableItem.EquipSlot.Left) {
            leftHand = item;
        }

        playerAnimator.animator.SetTrigger("Grab");
    }

    private void UnequipItem(EquipableItem item) {
        if (item.equipSlot == EquipableItem.EquipSlot.Right) {
            unequippedItem = rightHand;
            rightHand = new EquipableItem();
        }
        else if (item.equipSlot == EquipableItem.EquipSlot.Left) {
            unequippedItem = leftHand;
            leftHand = new EquipableItem();
        }

        playerAnimator.animator.SetTrigger("Grab");
    }

    private void OnGrabAnimationFinished() {
        // Equip
        if (rightHand.name != "Name") {
            print("right hand equip");
            rightHand.Instance.transform.parent = rightHand.pivotPoint;
            rightHand.Instance.transform.SetPositionAndRotation(rightHand.pivotPoint.position, rightHand.pivotPoint.rotation);
        }

        if (leftHand.name != "Name") {
            leftHand.Instance.transform.parent = leftHand.pivotPoint;
            leftHand.Instance.transform.SetPositionAndRotation(leftHand.pivotPoint.position, leftHand.pivotPoint.rotation);
        }

        // Unequip
        if (unequippedItem != null) {
            print("unequip");

            unequippedItem.Instance.transform.parent = backPivot;
            unequippedItem.Instance.transform.SetPositionAndRotation(backPivot.position, backPivot.rotation);

            unequippedItem = null;
        }

        print(rightHand.name);
    }
}
