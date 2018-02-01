using System;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[Serializable]
public class EquipableItem {

    public string name = "Name";
    public GameObject prefab;
    public bool equipable = true;
    public KeyCode equipKeyCode = KeyCode.Alpha1;
    public enum EquipSlot { Left, Right }
    public EquipSlot equipSlot = EquipSlot.Right;
    public Transform pivotPoint;
    public Sprite icon;

    private GameObject instance;
    public GameObject Instance {
        get {
            if (instance == null) {
                instance = UnityEngine.Object.Instantiate(prefab);
            }

            return instance;
        }
    }
}
