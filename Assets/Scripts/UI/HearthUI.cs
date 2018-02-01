using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthUI : MonoBehaviour {

    int i = 0;
    int j = PlayerHealth.hearts - 1;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heart14;
    public Sprite heart34;
    public Sprite heartEmpty;

    public Image[] heart;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;

    void Start()
    {
        heart = new Image[5];

        heart[0] = heart1;
        heart[1] = heart2;
        heart[2] = heart3;
        heart[3] = heart4;
        heart[4] = heart5;

        FillHearts();
    }

    void FillHearts()
    {
        for (i = 0; i < j + 1; i++) //Fills health bar to max at start
        {
            heart[i].sprite = heartFull;
        }
    }
	
	// Update is called once per frame
	void Update () {

        j = PlayerHealth.hearts - 1;

        if(PlayerHealth.hearts >= 2) //Heart below current max must be full
        {
            heart[j - 1].sprite = heartFull;
        }

        if(PlayerHealth.hearts >= 1)
        {
            if (PlayerHealth.heartPoints == 4)
            {
                heart[j].sprite = heartFull;
            }
            if (PlayerHealth.heartPoints == 3)
            {
                heart[j].sprite = heart34;
            }

            if (PlayerHealth.heartPoints == 2)
            {
                heart[j].sprite = heartHalf;
            }

            if (PlayerHealth.heartPoints == 1)
            {
                heart[j].sprite = heart14;
            }

            if (PlayerHealth.heartPoints == 0)
            {
                heart[j].sprite = heartEmpty;
            }
        }
        if (PlayerHealth.hearts <= 4 && PlayerHealth.hearts >= 0) //when hp lowers hearts disapear
        {
            heart[j + 1].sprite = heartEmpty;
        }
        if (PlayerHealth.hearts == -1) //When ded all hearts are gone
        {
            heart[j + 2].sprite = heartEmpty;
        }
	}
}
