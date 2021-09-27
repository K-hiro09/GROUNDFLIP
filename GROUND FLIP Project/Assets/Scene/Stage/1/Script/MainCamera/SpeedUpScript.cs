using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{
    Quaternion Rotation;
    Camera camera;
    Vector3 CameraPos;
    GameObject Player;
    GameObject EffectSpot;

    Vector3 SavePos;
    float SaveSize;
    Quaternion SaveRotation;
    private int OriginTimer;
    public int StateTimer;
    // Use this for initialization
    void Start()
    {
        GameManagerScript.Init();
        Rotation = transform.rotation;
        camera = GetComponent<Camera>();
        CameraPos = transform.position;
        Player = GameObject.Find("Player");
        EffectSpot = GameObject.Find("EffectSpot");

        SavePos = transform.position;
        SaveSize = camera.orthographicSize;
        SaveRotation = transform.rotation;

        OriginTimer = 0;
        StateTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManagerScript.SetPerformance(true);
        }
        if (GameManagerScript.GetPlayerAlive())
        {

            if (GameManagerScript.GetPerformance())
            {
                StateTimer++;
                if (StateTimer == 1) CameraRotation();
                if (StateTimer > 1)
                {
                    // カメラを傾ける
                    CameraTilt();
                }
                if (StateTimer > 50)
                {
                    // 元の位置に戻す
                    CameraOriginalPos();
                }
            }

        }
    }
    void CameraRotation()
    {
        transform.Rotate(0.0f, 0.0f, -10.0f);
    }

    void CameraTilt()
    {
        camera.orthographicSize = 3.0f;
        CameraPos.x = Player.transform.position.x + 2.5f;
        CameraPos.y = Player.transform.position.y;
        transform.position = CameraPos;
        //GameManagerScript.SetPerformance(true);
    }

    void CameraOriginalPos()
    {
        GameManagerScript.SetPerformance(false);
        Rotation = SaveRotation;
        camera.orthographicSize = SaveSize;
        CameraPos = SavePos;
        transform.rotation = Rotation;
        transform.position = CameraPos;
        enabled = false;
    }

}
