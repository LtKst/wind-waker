using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potje : MonoBehaviour {

    public GameObject heartPotje;

    bool deletePieces = false;
    int timer = 100;

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject piece5;
    public GameObject piece6;
    public GameObject piece7;
    public GameObject piece8;

    public GameObject[] pieces;

    private void Start()
    {
        pieces = new GameObject[8];
        pieces[0] = piece1;
        pieces[1] = piece2;
        pieces[2] = piece3;
        pieces[3] = piece4;
        pieces[4] = piece5;
        pieces[5] = piece6;
        pieces[6] = piece7;
        pieces[7] = piece8;

        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].GetComponent<Rigidbody>().useGravity = false;
            pieces[i].GetComponent<Rigidbody>().detectCollisions = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            this.GetComponent<SphereCollider>().enabled = false;
            GameObject potje = Instantiate(heartPotje, transform.parent, false);
            potje.transform.position = transform.position;
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].GetComponent<Rigidbody>().useGravity = true;
                pieces[i].GetComponent<Rigidbody>().detectCollisions = true;
                deletePieces = true;
            }
        }
    }

    void Update()
    {
        if(deletePieces == true)
        {
            timer -= 1;
            /*
            for (int i = 0; i < pieces.Length; i++)
            {
                if(pieces[i].transform.localScale.x != 0)
                {
                    pieces[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
            */
        }
        if(timer <= 0)
        {
            deletePieces = false;
            Destroy(gameObject);
        }
    }
}
