using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage1 : MonoBehaviour {

    private int SceneChangeTimer;
    private int RewindTimer;
    // Use this for initialization
    void Start ()
    {
        GameManagerScript.Init();
        FadeManager.FadeIn();
        SceneChangeTimer = 0;
        RewindTimer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameManagerScript.SetGameTimer(1);
        GameManagerScript.SetStageNumber(1);
        //Player死亡時
        if (!GameManagerScript.GetPlayerAlive())
        {
            SceneChangeTimer++;
            if (SceneChangeTimer >= 90)
            {
                FadeManager.FadeOut(2);
                SceneChangeTimer = 0;
            }
        }
    }
}
