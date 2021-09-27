using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScoreScript : MonoBehaviour {
    private Vector3 Vec;

    public float Speed;
    private Transform Target;
    private Vector3 Pos;
    private int Timer;
    public bool Hit;
    void Start()
    {
        Target = GameObject.Find("ScoreHitPos").transform;
        Pos = transform.position;
        Hit = false;
        Timer = 0;
    }
    void OnTriggerEnter2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "Score")
        {
            Hit = true;
            //Timer = 0;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Hit)
        {
            GameManagerScript.SetHitScoreStar(true);
        }
        Tracking();
    }

    void Tracking()
    {
        Timer++;

        // 右に移動してから
        if (Timer <= 10)
        {
            Pos.x += 1 * Time.deltaTime;
            transform.position = Pos;
        }
        // スコアテキストに吸い込まれる
        if (Timer >=10)
        {
            Vec = Target.position - transform.position;
            Vec = Vec.normalized;
            transform.position += new Vector3(Vec.x * Speed, Vec.y * Speed, 0.0f);
        }
    }


}
