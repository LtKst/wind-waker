using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupee : MonoBehaviour {

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Destroy(gameObject);
            RupeeUI.Rupee += 1;
        }
    }
}
