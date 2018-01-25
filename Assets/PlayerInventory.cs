using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PlayerInventory : MonoBehaviour {

    [SerializeField]
    private BackItem[] backItems;

    private BackItem equippedItem;

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

    private void EquipItem(BackItem item) {
        UnequipItem(equippedItem);

        if (item.rightHand) {
            item.Instance.transform.parent = rightHand;
            item.Instance.transform.SetPositionAndRotation(rightHand.position, rightHand.rotation);
        } else {
            item.Instance.transform.parent = leftHand;
            item.Instance.transform.SetPositionAndRotation(leftHand.position, leftHand.rotation);
        }

        equippedItem = item;
    }

    private void UnequipItem(BackItem item) {
        if (item != null) {
            item.Instance.transform.parent = back;
            item.Instance.transform.SetPositionAndRotation(back.position, back.rotation);

            if (equippedItem == item) {
                equippedItem = null;
            }
        }
    }
}
