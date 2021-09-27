using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTitle : MonoBehaviour
{
    private int timer;
    private bool flg;
    // Use this for initialization
    void Start()
    {
        GameManagerScript.Init();
        FadeManager.FadeIn();
        timer = 0;
        flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        // シーン変更
        if (Input.GetMouseButton(0))
        {
            FadeManager.FadeOut(1);
            flg = true;
        }

    }
}
