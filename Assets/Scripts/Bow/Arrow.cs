using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    private Rigidbody _arrowRB;
    private Rigidbody _childRB;
    private Rigidbody[] bodys;

    private void Start() {
        bodys = GetComponentsInChildren<Rigidbody>();
        _arrowRB = gameObject.GetComponent<Rigidbody>();
        _arrowRB.isKinematic = true;
        
        for(int i = 0; i < bodys.Length; i++) {
            bodys[i].isKinematic = true;
        }
    }

    public void AddVelocity(float power) {
        print("arrow.av");
        _arrowRB.isKinematic = false;
        
        for (int i = 0; i < bodys.Length; i++) {
            bodys[i].isKinematic = false;
        }

        _arrowRB.AddForce(transform.forward * power, ForceMode.Impulse);
        bodys[0].AddForce(transform.forward * power, ForceMode.Impulse);
    }
}
