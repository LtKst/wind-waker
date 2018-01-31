using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by: Gijs Schouten.
/// </summary>

public class Arrow : MonoBehaviour {
    private Rigidbody _arrowRB;
    private BoxCollider _arrowColl;
    private GameObject bow;
    private float _maxSpeed;
    private float _currentSpeed;
    private float _clampSize;

    private void Start() {
        bow = GameObject.FindGameObjectWithTag("Bow");
        _maxSpeed = bow.GetComponent<Bow>().maxSpeed;
        _arrowRB = gameObject.GetComponent<Rigidbody>();
        _arrowColl = gameObject.GetComponent<BoxCollider>();
        _arrowRB.isKinematic = true;
        
    }

    public void AddVelocity(float power) {
        print("arrow.av");
        _arrowRB.isKinematic = false;
        _arrowRB.AddForce(transform.forward * power, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Arrow") {
            _currentSpeed = bow.GetComponent<Bow>().speed;
            _clampSize = Mathf.Clamp(_currentSpeed / _maxSpeed, 0.2f, 0.8f);
            print(_clampSize);
            Vector3 size = _arrowColl.size;
            size.y = _clampSize;
            _arrowColl.size = size;
            _arrowRB.isKinematic = true;
        }
    }

    void FixedUpdate() {
        if (_arrowRB.velocity != Vector3.zero)
            _arrowRB.rotation = Quaternion.LookRotation(_arrowRB.velocity);
    }
}
