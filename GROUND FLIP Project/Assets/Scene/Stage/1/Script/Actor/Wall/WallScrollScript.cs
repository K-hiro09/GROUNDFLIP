using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScrollScript : MonoBehaviour
{
    public float ScrollSpeed = 0.01f;
    public float DeleteX;
    public float NewX, NewY;
    void Update()
    {
        if (GameManagerScript.GetPlayerAlive())
        {
            transform.Translate(-ScrollSpeed, 0.0f, 0);
        }
        if (transform.position.x <= DeleteX)
        {
            transform.position = new Vector3(NewX, NewY, 0.0f);
        }
        if (GameManagerScript.GetPlayerContinuDead())
        {
            transform.Translate(+ScrollSpeed, 0.0f, 0);
        }

        //各ステージゴールしたとき
        if (GameManagerScript.GetWaveCount() == 17 && GameManagerScript.GetStageNumber() == 1)
        {
            ScrollSpeed = 0.05f;
            GameManagerScript.SetSpeedUpFlg(false);
            GameManagerScript.SetPerformance(false);
        }
        if (GameManagerScript.GetWaveCount() == 12 && GameManagerScript.GetStageNumber() == 2)
        {
            ScrollSpeed = 0.05f;
            GameManagerScript.SetSpeedUpFlg(false);
            GameManagerScript.SetPerformance(false);
        }
        if (GameManagerScript.GetWaveCount() == 10 && GameManagerScript.GetStageNumber() == 3)
        {
            ScrollSpeed = 0.05f;
            GameManagerScript.SetSpeedUpFlg(false);
            GameManagerScript.SetPerformance(false);
        }
    }
}