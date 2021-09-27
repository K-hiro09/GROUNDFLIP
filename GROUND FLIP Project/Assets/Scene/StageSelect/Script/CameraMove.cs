using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Mouse mouse;
    private Vector3 Move;
    // Use this for initialization
    void Start()
    {
        Move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラ位置を上下に移動
        if (mouse.Stage1from2)
        {
            Move.y -= 1.0f;
            if (Move.y <= -10.0f)
            {
                Move.y = -10.0f;
                GameManagerScript.SetAudioNum(2);
                mouse.Stage1from2 = false;
            }

        }
        else if (mouse.Stage2from1)
        {
            Move.y += 1.0f;
            if (Move.y >= 0.0f)
            {
                Move.y = 0.0f;
                GameManagerScript.SetAudioNum(1);
                mouse.Stage2from1 = false;
            }
        }

        else if (mouse.Stage2from3)
        {
            Move.y -= 1.0f;
            if (Move.y <= -20.0f)
            {
                Move.y = -20.0f;
                GameManagerScript.SetAudioNum(3);
                mouse.Stage2from3 = false;
            }
        }

        else if (mouse.Stage3from2)
        {
            Move.y += 1.0f;
            if (Move.y >= -10.0f)
            {
                Move.y = -10.0f;
                GameManagerScript.SetAudioNum(2);

                mouse.Stage3from2 = false;
            }
        }

        else if (mouse.Stage3from4)
        {
            Move.y -= 1.0f;
            if (Move.y <= -30.0f)
            {
                Move.y = -30.0f;
                GameManagerScript.SetAudioNum(4);
                mouse.Stage3from4 = false;
            }
        }

        else if (mouse.Stage4from3)
        {
            Move.y += 1.0f;
            if (Move.y >= -20.0f)
            {
                Move.y = -20.0f;
                GameManagerScript.SetAudioNum(3);
                mouse.Stage4from3 = false;
            }
        }

        transform.position = Move;
    }
}
