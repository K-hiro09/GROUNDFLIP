using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3BgmCheck : MonoBehaviour
{
    private AudioSource _AudioSource;
    private float HighPointTime;        // BGMのサビ部分の時間
    // Use this for initialization
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        HighPointTime = 35.4773f;
    }
    // Update is called once per frame
    void Update()
    {
        if (_AudioSource.time >= HighPointTime)
        {
            GameManagerScript.SetPerformance(true);
            GameManagerScript.SetSpeedUpFlg(true);
            enabled = false;
        }
    }
}