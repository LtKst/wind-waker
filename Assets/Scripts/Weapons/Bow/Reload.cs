using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {
    private GameObject _bow;
    private GameObject _arrow;

    private void Start() {
        _bow = GameObject.FindGameObjectWithTag("Bow");
    }

    private void DrawArrow() {
        _arrow = _bow.GetComponent<Bow>().currentArrow;
    }
}
