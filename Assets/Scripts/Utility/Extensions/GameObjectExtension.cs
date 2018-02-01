using UnityEngine;

/// <summary>
/// Extra methods for GameObjects
/// Made by Koen Sparreboom
/// </summary>
public static class GameObjectExtension {

    public static GameObject FindChildWithTag(this GameObject obj, string tag) {
        foreach (Transform child in obj.transform) {
            if (child.tag == tag) {
                return child.gameObject;
            }
        }

        return null;
    }
}
