using UnityEngine;

public class LekkerLerpje : MonoBehaviour {

    [SerializeField]
    private Transform a;
    [SerializeField]
    private Transform b;
    [SerializeField]
    private Transform c;


    private float currentStep;
    [SerializeField]
    private float speed = 0.0001f;

	private void Update () {
        transform.position = Vector3Utility.QuadraticLerp(a.position, b.position, c.position, currentStep += speed * Time.deltaTime);
    }
}
