using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFont : MonoBehaviour {

    Vector3 Scale;
    Vector3 Pos;

	void Start () {
        Scale = transform.localScale;
        Pos = transform.position;
    }
	
	void Update () {

        // Player壁位置によって向き位置変更
        if (GameManagerScript.GetPlayerWallWhich() == 1) //上
        {
            Scale.y = -1.742651f;
            Pos.y = -1.83f;
        }
        else
        {
            Scale.y = 1.742651f;
            Pos.y = 1.83f;
        }

        transform.localScale = Scale;
        transform.position = Pos;
	}
}
