using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    Vector3 Pos;
    public float Speed = 0.2f;
    private Animator _Animation;
    // Use this for initialization
    void Start()
    {
        Speed = 0.2f;
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.GetPlayerAlive())
        {
            Pos.x -= Speed;
        }
        if (GameManagerScript.GetSpeedUpFlg() && GameManagerScript.GetWaveCount() < 17)
        {
            Speed = 0.25f;
        }

        if (GameManagerScript.GetWaveCount() == 17 && GameManagerScript.GetStageNumber() == 1)
        {
            Speed = 0.05f;
        }
        if (GameManagerScript.GetWaveCount() == 12 && GameManagerScript.GetStageNumber() == 2)
        {
            Speed = 0.05f;
        }
        if (GameManagerScript.GetWaveCount() == 10 && GameManagerScript.GetStageNumber() == 3)
        {
            Speed = 0.05f;

        }
        transform.position = Pos;
    }
}
