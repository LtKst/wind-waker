using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public static int hearts = 5;        //The actual hearts
    public static int heartPoints = 4;   //The heart pieces, 4 slices
    public static bool invis = false;    //When the player is imume against enemy attacks

    GameObject GameOver;
    GameObject UI;

    GameObject _player;
    GameObject _uiBackground;

    int i = 0; //ms
    int j = 0; //0.5 sec

    //Checks if the player hits an enemy, then takes away some heartpoints and makes him imume
    private void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.tag == "Enemy" && invis == false)
        {
            heartPoints -= 1;
            invis = true;
        }
    }

    void Start()
    {
        GameOver = GameObject.Find("GameOver");
        UI = GameObject.Find("UI");
        GameOver.SetActive(false);
        _player = GameObject.Find("Main Camera");
        _uiBackground = GameObject.Find("background");
    }

    //checks how many hp the player has, and when hes imume
    void Update()
    {

        Debug.Log("Hearts" + hearts);
        Debug.Log("heart points" + heartPoints);
        if(heartPoints < 0)
        {
            hearts -= 1;
            heartPoints += 4;
        }

        if(invis == true)
        {
            InvisTimer();
        }

        if(hearts <= 1 && heartPoints <= 0)
        {
            Dead();
            hearts = -1;
        }

    }

    //How long the player is immune
    void InvisTimer()
    {
        i += 1;

        if(i >= 50)
        {
            i = 0;
            j += 1;
        }

        if(j >= 1)
        {
            invis = false;
            j = 0;
        }
    }

    //Player is dead
    void Dead()
    {
        Debug.Log("ded");
        Time.timeScale = 0f;
        UI.SetActive(false);
        GameOver.SetActive(true);
        _player.GetComponent<CameraController>().enabled = false;
        _uiBackground.GetComponent<Image>().CrossFadeAlpha(0.1f,2.0f,true);
    }

    //Adds Hearts
    public void AddHP()
    {
        Debug.Log("loaded");
        if(heartPoints < 4)
        {
            heartPoints += 4;
        }
        if(hearts == 5)
        {
            if (heartPoints == 3)
            {
                heartPoints += 1;
            }
            if (heartPoints == 2)
            {
                heartPoints += 2;
            }
            if (heartPoints == 1)
            {
                heartPoints += 3;
            }
        }
        if (heartPoints > 4)
        {
            heartPoints -= 4;
            hearts += 1;
        }
    }
}
