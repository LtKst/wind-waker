using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour {
    private GameObject _player;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, _player.transform.position,1);
    }
}
