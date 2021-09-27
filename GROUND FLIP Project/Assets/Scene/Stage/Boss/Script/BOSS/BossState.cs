using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    public enum Motion
    {
        SHAPED_8 = 1,       //8の字に動く
        ORIGINAL_POS,       //定位置に戻る
        ROCKON_BODYBLOW,    //Playerをロックオンし体当たり
        STAGECOLOR_CHANGE,  //ステージのデザインを変更
        LASER,              //ステージがStage3(赤)から使用
        COLOR_THROW,        //色の付いたオブジェクトを投げる計4回
        GOAL_IN,            //ゴールに吸い込まれ吐き出される
        RED_EYE,            //吐き出されると赤目だけ残る
        DEAD                //赤目を踏まれると死亡
    }
    public Motion State;

    private int Wait;
    private float Angle;
    private Vector3 Move;
    private Vector3 Pos;
    private Transform OriginPos;
    private Transform Target;
    private float Rotation;

    public bool Hit;
    public bool RockOn;

    // Use this for initialization
    void Start()
    {
        State = 0;

        Wait = 0;
        RockOn = false;
        Angle = 0.0f;
        Rotation = 0.0f;
        Hit = false;

        Pos = transform.position;
        OriginPos = GameObject.Find("BossOriginPos").transform;
        Target = GameObject.Find("Alignment").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case Motion.SHAPED_8:
                Shaped8();
                break;
            case Motion.ORIGINAL_POS:
                OriginPosition();
                break;
            case Motion.ROCKON_BODYBLOW:
                RockOnBodyBlow();
                break;
        }
    }

    void Shaped8()
    {
        Angle += 0.05f;
        Move.x = (Mathf.Sin(Angle) * 5);
        Move.y = (Mathf.Sin(Angle * 2) * 1);
        transform.position = Pos + Move;
        if (Angle >= 15.0f)
        {
            State = Motion.ORIGINAL_POS;
        }
    }

    void OriginPosition()
    {
        Chase(OriginPos.position, transform.position, 0.2f);
        if(Chase(OriginPos.position, transform.position, 0.2f).z == 1.0f)
        {
            State = Motion.ROCKON_BODYBLOW;
        }
        //State = Motion.ROCKON_BODYBLOW;
    }

    void RockOnBodyBlow()
    {
        Rotation += 0.05f;
        transform.Rotate(0.0f, 0.0f, Rotation);
        //Rotation += 0.05f;
        if(!Hit)RockOn = true;
        if (Rotation >= 15.0f)
        {
            RockOn = false;
            Chase(Target.position, transform.position, 0.5f);
        }

        if (Hit)
        {
            Rotation -= 0.1f;
            if (Rotation <= 0.0f)
            {
                Rotation = 0.0f;
                Hit = false;
                //State = Motion.ORIGINAL_POS;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alignment")
        {
            Hit = true;
        }
    }

    // 追跡
    Vector3 Chase(Vector3 A, Vector3 B, float Speed)
    {
        Vector3 Vec = A - B;
        Vec = Vec.normalized;
        transform.position += new Vector3(Vec.x * Speed, Vec.y * Speed, 0.0f);
        return Vec;
    }
}
