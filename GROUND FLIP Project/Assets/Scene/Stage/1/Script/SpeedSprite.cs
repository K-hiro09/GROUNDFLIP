using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSprite : MonoBehaviour
{
    private SpriteRenderer Sp;
    private GameObject SpeedFont;
    private GameObject UpFont;
    private Vector3 SpeedPos;
    private Vector3 UpPos;
    private float Speed;
    // Use this for initialization
    void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
        Sp.enabled = false;
        SpeedFont = GameObject.Find("Speed");
        UpFont = GameObject.Find("UP");
        SpeedPos = SpeedFont.transform.position;
        UpPos = UpFont.transform.position;
        Speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.GetPerformance())
        {
            Sp.enabled = true;
            //上の壁にいるとき
            if (GameManagerScript.GetPlayerWallWhich() == 0)
            {
                PosDown();
            }

            //下の壁にいるとき
            if (GameManagerScript.GetPlayerWallWhich() == 1)
            {
                PosUp();
            }
        }
        SpeedFont.transform.position = SpeedPos;
        UpFont.transform.position = UpPos;
    }

    //上側に表示
    void PosDown()
    {
        SpeedPos.y = -3.87f;
        UpPos.y = -5.17f;
        SpeedPos.x += Speed;
        UpPos.x -= Speed - 1.0f;
        if (SpeedPos.x >= -1.94f) SpeedPos.x = -1.94f;
        if (UpPos.x <= -1.94f) UpPos.x = -1.94f;
        Destroy(gameObject, 0.8f);
    }

    //下側に表示
    void PosUp()
    {
        SpeedPos.y = 3.4f;
        UpPos.y = 1.9f;
        SpeedPos.x += Speed;
        UpPos.x -= Speed - 1.0f;
        if (SpeedPos.x >= -1.67f) SpeedPos.x = -1.67f;
        if (UpPos.x <= -1.67f) UpPos.x = -1.67f;
        Destroy(gameObject, 0.8f);
    }

}
