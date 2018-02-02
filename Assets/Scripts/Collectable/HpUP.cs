using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUP : MonoBehaviour {

    private GameObject _player;
    PlayerHealth playerhealth;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = _player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player" && PlayerHealth.hearts < 5 || coll.tag == "Player" && PlayerHealth.hearts == 5 && PlayerHealth.heartPoints < 4)
        {
            playerhealth.AddHP();
            Destroy(gameObject);
        }
    }

}
