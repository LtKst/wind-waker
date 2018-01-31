using UnityEngine;

/// <summary>
/// Extra random methods
/// Made by Koen Sparreboom
/// </summary>
public static class RandomUtility {

    public static bool RandomBool() {
        return Random.Range(0, 2) == 0;
    }
}
