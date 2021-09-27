using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour {
    int SceneChangeTimer;
    [SerializeField]
    public int stage3Now;
    // Use this for initialization
    void Start () {
        GameManagerScript.Init();
        FadeManager.FadeIn();
        SceneChangeTimer = 0;
        //FindObjectOfType<Stage2>().stage2Now = 0;
    }

    // Update is called once per frame
    void Update () {
        GameManagerScript.SetGameTimer(1);
        GameManagerScript.SetStageNumber(3);
        if (!GameManagerScript.GetPlayerAlive())
        {
            SceneChangeTimer++;
            if (SceneChangeTimer >= 90)
            {
                FadeManager.FadeOut(4);
                SceneChangeTimer = 0;
            }
        }
    }

}
