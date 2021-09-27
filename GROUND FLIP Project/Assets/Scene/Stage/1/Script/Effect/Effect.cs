using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Vector3 Scale;
    SpriteRenderer Sp;
    // どの程度回転させるか
    public float RotaionNum;

    // どの程度の拡縮をするのか
    public float ScaleX;
    public float ScaleY;

    // どの程度透明度を下げるか
    private float Alpha;
    public float _Alpha;

    // どの程度時間が経ったら削除するか
    //public float DestoryTime;

    // Playerが上下どちらにいるかで向きを変える
    private Quaternion Rotation;
    // 向きを変えるのを使用するか否か
    public bool RotationUse;
    // Use this for initialization
    void Start()
    {
        Scale = transform.localScale;
        Sp = GetComponent<SpriteRenderer>();
        Alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScale();
        ChangeRotation();
        ChangeAlpha();
    }

    void ChangeScale()
    {
        Scale.x += ScaleX;
        Scale.y += ScaleY;
        transform.localScale = Scale;
    }

    void ChangeRotation()
    {
        // 回転
        transform.Rotate(0.0f, 0.0f, RotaionNum);
        // Playerが上の壁に居るとき
        if (GameManagerScript.GetPlayerWallWhich() == 1 && RotationUse)
        {
            Rotation.z = 180.0f;
            transform.rotation = Rotation;
        }
        // Playerが下の壁に居るとき
        if (GameManagerScript.GetPlayerWallWhich() == 0 && RotationUse)
        {
            Rotation.z = 0.0f;
            transform.rotation = Rotation;
        }
    }

    void ChangeAlpha()
    {
        Alpha -= _Alpha;
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
        if (Alpha <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
