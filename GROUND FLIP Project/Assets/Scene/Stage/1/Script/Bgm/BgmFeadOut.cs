using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFeadOut : MonoBehaviour
{
    private AudioSource _AudioSource;
    private float S1AudioMax;
    private float S2AudioMax;
    private float S3AudioMax;

    // Use this for initialization
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        S1AudioMax = 120.0f;
        S2AudioMax = 103.0f;
        S3AudioMax = 90.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameManagerScript.SetNowAudioTime(_AudioSource.time);
        if (GameManagerScript.GetStageNumber() == 1)
        {
            GameManagerScript.SetMaxAudioTime(S1AudioMax);
        }
        else if (GameManagerScript.GetStageNumber() == 2)
        {
            GameManagerScript.SetMaxAudioTime(S2AudioMax);
        }
        if (GameManagerScript.GetStageNumber() == 3)
        {
            GameManagerScript.SetMaxAudioTime(S3AudioMax);
        }
        FeadOut();
    }
    void FeadOut()
    {
        //各ステージゴール時ボリュームを徐々に下げる
        if (GameManagerScript.GetWaveCount() == 17 && GameManagerScript.GetStageNumber() == 1)
        {
            _AudioSource.volume -= 0.01f;
        }

        if (GameManagerScript.GetWaveCount() == 12 && GameManagerScript.GetStageNumber() == 2)
        {
            _AudioSource.volume -= 0.01f;
        }

        if (GameManagerScript.GetWaveCount() == 10 && GameManagerScript.GetStageNumber() == 3)
        {
            _AudioSource.volume -= 0.01f;
        }
    }
}
