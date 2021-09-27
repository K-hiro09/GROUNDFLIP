using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrool : MonoBehaviour
{
    float x = 0.05f;
    public float DeletePosX;
    public float NewX, NewY;

    void Update()
    {
        if (GameManagerScript.GetPlayerAlive())
        {
            transform.Translate(-x, 0.0f, 0);
        }
        if (transform.position.x < DeletePosX)
        {
            transform.position = new Vector3(NewX, NewY, 0.0f);
        }
        if (GameManagerScript.GetPlayerContinuDead())
        {
            transform.Translate(+x, 0.0f, 0);
        }

        if (GameManagerScript.GetSpeedUpFlg())
        {
            x = 0.15f;
        }

        //各ステージゴール時、背景の速度を落とす
        if (GameManagerScript.GetWaveCount() == 17 && GameManagerScript.GetStageNumber() == 1)
        {
            x = 0.03f;
        }
        if (GameManagerScript.GetWaveCount() == 12 && GameManagerScript.GetStageNumber() == 2)
        {
            x = 0.03f;
        }
        if (GameManagerScript.GetWaveCount() == 10 && GameManagerScript.GetStageNumber() == 3)
        {
            x = 0.03f;
        }
    }
    //-28.35,-0.037
}