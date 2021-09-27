using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontFrameChange : MonoBehaviour
{
    public SpriteRenderer[] Frame;
    public SpriteRenderer[] Font;
    // Use this for initialization
    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            Frame[i].enabled = false;
            Font[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < 4; i++)
        {
            Frame[i].sortingOrder = 3;
            Font[i].sortingOrder = 3;
        }

        //各ステージに合わせてSpriteの表示非表示
        if (GameManagerScript.GetAudioNum() == 1)
        {
            Frame[0].enabled = true;
            Frame[1].enabled = false;
            Font[0].enabled = true;
            Font[1].enabled = false;

            Frame[2].enabled = false;
            Frame[3].enabled = false;
            Font[2].enabled = false;
            Font[3].enabled = false;
        }

        if (GameManagerScript.GetAudioNum() == 2)
        {
            Frame[1].enabled = true;
            Frame[0].enabled = false;
            Font[1].enabled = true;
            Font[0].enabled = false;

            Frame[2].enabled = false;
            Frame[3].enabled = false;
            Font[2].enabled = false;
            Font[3].enabled = false;
        }

        if (GameManagerScript.GetAudioNum() == 3)
        {
            Frame[2].enabled = true;
            Frame[1].enabled = false;
            Font[2].enabled = true;
            Font[1].enabled = false;

            Frame[0].enabled = false;
            Frame[3].enabled = false;
            Font[0].enabled = false;
            Font[3].enabled = false;
        }

        if (GameManagerScript.GetAudioNum() == 4)
        {
            Frame[3].enabled = true;
            Frame[2].enabled = false;
            Font[3].enabled = true;
            Font[2].enabled = false;

            Frame[0].enabled = false;
            Frame[1].enabled = false;
            Font[0].enabled = false;
            Font[1].enabled = false;
        }

    }
}
