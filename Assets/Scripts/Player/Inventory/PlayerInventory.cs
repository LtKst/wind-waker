using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PlayerInventory : MonoBehaviour {

    [SerializeField]
    private EquipableItem[] backItems;

    private EquipableItem equippedItem;

    [SerializeField]
    private float equipTime = 0.833334f;

    [SerializeField]
    private Transform back;

    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;

    private void Start() {
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
                } else {
                    EquipItem(backItems[i]);
                }
            }
        }
    }

    private void EquipItem(EquipableItem item) {
        UnequipItem(equippedItem);

        GetComponent<Animator>().SetTrigger("Grabbing");

        equippedItem = item;
    }

    private void OnGrabAnimationFinished() {
        if (equippedItem.equipSlot == EquipableItem.EquipSlot.Right) {
            equippedItem.Instance.transform.parent = rightHand;
            equippedItem.Instance.transform.SetPositionAndRotation(rightHand.position, rightHand.rotation);
        }
        else {
            equippedItem.Instance.transform.parent = leftHand;
            equippedItem.Instance.transform.SetPositionAndRotation(leftHand.position, leftHand.rotation);
        }
    }

    private void UnequipItem(EquipableItem item) {
        if (item != null) {
            item.Instance.transform.parent = back;
            item.Instance.transform.SetPositionAndRotation(back.position, back.rotation);

            if (equippedItem == item) {
                equippedItem = null;
            }
        }
    }
}
