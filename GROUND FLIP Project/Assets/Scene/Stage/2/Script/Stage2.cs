using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour {
    private int SceneChangeTimer;

    // Use this for initialization
    void Start ()
    {
        GameManagerScript.Init();
        FadeManager.FadeIn();
        SceneChangeTimer = 0;
    }

    // Update is called once per frame
    void Update () {
        GameManagerScript.SetGameTimer(1);
        GameManagerScript.SetStageNumber(2);

        if (!GameManagerScript.GetPlayerAlive())
        {
            SceneChangeTimer++;
            if (SceneChangeTimer >= 90)
            {
                FadeManager.FadeOut(3);
                SceneChangeTimer = 0;
            }
        }
    }
}
