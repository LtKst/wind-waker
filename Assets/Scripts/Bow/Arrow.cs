using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    private Rigidbody _arrowRB;
    private Rigidbody _childRB;

    private void Start() {
        _arrowRB = gameObject.GetComponent<Rigidbody>();
        //_arrowRB.centerOfMass = new Vector3(0, 0, 10);
        _arrowRB.isKinematic = true;
        
    }

    public void AddVelocity(float power) {
        print("arrow.av");
        _arrowRB.isKinematic = false;

        _arrowRB.AddForce(transform.forward * power, ForceMode.Impulse);
    }

    void FixedUpdate() {
        if (_arrowRB.velocity != Vector3.zero)
            _arrowRB.rotation = Quaternion.LookRotation(_arrowRB.velocity);
    }
}
