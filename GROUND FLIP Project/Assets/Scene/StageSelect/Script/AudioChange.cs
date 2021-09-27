using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChange : MonoBehaviour
{
    public AudioSource[] StageAudio;

    // Update is called once per frame
    void Update()
    {
        //各ステージごとに再生させるBGMを変更
        if (GameManagerScript.GetAudioNum() == 1)
        {
            StageAudio[0].enabled = true;
            StageAudio[1].enabled = false;
            StageAudio[2].enabled = false;
            StageAudio[3].enabled = false;
        }

        else if (GameManagerScript.GetAudioNum() == 2)
        {
            StageAudio[1].enabled = true;
            StageAudio[0].enabled = false;
            StageAudio[2].enabled = false;
            StageAudio[3].enabled = false;
        }

        else if (GameManagerScript.GetAudioNum() == 3)
        {
            StageAudio[2].enabled = true;
            StageAudio[0].enabled = false;
            StageAudio[1].enabled = false;
            StageAudio[3].enabled = false;
        }

        else if (GameManagerScript.GetAudioNum() == 4)
        {
            StageAudio[3].enabled = true;
            StageAudio[0].enabled = false;
            StageAudio[1].enabled = false;
            StageAudio[2].enabled = false;
        }
    }
}
