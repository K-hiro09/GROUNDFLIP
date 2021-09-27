using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGuide : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Pos;
    private float Dist;           // 障害物とプレイヤーの距離
    private Animator _Animator; 
    private SpriteRenderer Sp;
    private float Alpha;          // 透明度
    private int SEtime;
    private AudioSource _AudioSource;
    public List<AudioClip> _AudioClip = new List<AudioClip>();

    public GameObject GuideEffect;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        _Animator = GetComponent<Animator>();
        Sp = GetComponent<SpriteRenderer>();
        _AudioSource = gameObject.AddComponent<AudioSource>();

        //_Animator.enabled = false;  // アニメーションを実行しない
        Sp.enabled = false;         // 描画しない
        Alpha = 0.0f;
        SEtime = 0;
    }

    // Update is called once per frame
    void Update () {
        DistMethod();
    }

    void DistMethod()
    {
        Pos = transform.position;
        Dist = Vector3.Distance(Pos, Player.transform.position);

        // 距離が16より小さくプレイヤーが下の壁にいたら
        if (Dist <= 16.0f)
        {
            if (GameManagerScript.GetPlayerWallWhich() == 0)
            {
                _Animator.SetBool("OkF", false);
                _Animator.SetBool("JumpF", true);
                SEtime++;           // SE再生タイマー
                Sp.enabled = true;  // 描画する
                Alpha += 0.1f;      // 透明度加算
            }
        }
        if (SEtime == 1)
        {
            _AudioSource.PlayOneShot(_AudioClip[0]);
            // ガイドが表示されたときのエフェクトを生成
            GameObject GuideEf = Instantiate(GuideEffect, transform.position, Quaternion.identity);
            //0.1秒後に削除
            Destroy(GuideEf, 0.1f);
        }

        // 透明度固定
        if (Alpha >= 1.0f)
        {
            Alpha = 1.0f;
        }

        // 描画されていて上壁にいたら
        if (Sp.enabled)
        {
            if (GameManagerScript.GetPlayerDir() == 1||GameManagerScript.GetPlayerWallWhich()==1)
            {
                // アニメーション再生
                _Animator.SetBool("JumpF", false);
                _Animator.SetBool("OkF", true);
                //_Animator.enabled = true;   // プレイヤーが障害物を避けたら「OK!」が表示される
            }
            if (Input.GetMouseButtonDown(0))
            {
                _AudioSource.PlayOneShot(_AudioClip[1]);
                GameObject GuideEf = Instantiate(GuideEffect, transform.position, Quaternion.identity);
                Destroy(GuideEf, 0.1f);
            }
        }

        if (Pos.x <= Player.transform.position.x)
        {
            Alpha -= 0.1f;
            if (Alpha <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
    }

}
