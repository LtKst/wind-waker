using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potje : MonoBehaviour {

    public GameObject heartPotje;
    Transform location;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            Instantiate(heartPotje);
            Destroy(gameObject);
        }
    }
}
