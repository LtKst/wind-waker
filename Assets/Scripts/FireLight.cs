using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Light))]
public class FireLight : MonoBehaviour {

    private Light _light;
    private Color initialColor;
    private float timePassed;
    private float changeValue;

    private void Start() {
        _light = GetComponent<Light>();

        initialColor = _light.color;
    }

    private void Update() {
        timePassed = Time.time;
        timePassed -= Mathf.Floor(timePassed);

        _light.color = initialColor * CalculateChange();
    }

    private float CalculateChange() {
        changeValue = -Mathf.Sin(timePassed * 12 * Mathf.PI) * 0.05f + 0.8f;
        return changeValue;
    }
}
