using UnityEngine;

/// <summary>
/// Extra methods for Vector3s
/// Made by Koen Sparreboom
/// </summary>
public static class Vector3Utility {

    public static Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t) {
        Vector3 p0 = Vector3.Lerp(a, b, t);
        Vector3 p1 = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(p0, p1, t);
    }
}
