using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    #region Variable
    Rigidbody2D R2d;
    public float JumpSpeed;

    Vector3 Scale;
    Vector3 SaveScale;

    public bool RightClickUse;
    float ClickTime;
    bool RightClickCheck;
    public bool RightClickNow=false;
    public int DelayTimer;
    public int DelayTime;  // 着地時の遅延時間

    float Alpha;

    SpriteRenderer Sp;
    BoxCollider2D Bc2d;
    GameObject Summon;

    private Animator _Animator;
    private ParticleSystem ps;
    #endregion
    PlayerGoal playerGoal = new PlayerGoal();
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;

        R2d = GetComponent<Rigidbody2D>();
        Scale = transform.localScale;
        SaveScale = Scale;

        ClickTime = 0;
        DelayTimer = 0;
        RightClickCheck = false;
        RightClickNow = false;

        Alpha = 1.0f;
        Sp = GetComponent<SpriteRenderer>();
        Bc2d = GetComponent<BoxCollider2D>();

        Summon = GameObject.Find("SummonPos");
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManagerScript.GetPlayerAlive()) return;

        if (!GameManagerScript.GetPlayerContinuDead())
        {
            Jump();
            TwoJump();
            AlphaChange();
        }

        //各ステージゴール時Playerのアニメの速度を落とす
        if (GameManagerScript.GetStageNumber() == 1)
        {
            if (GameManagerScript.GetWaveCount() == 9)
            {
                _Animator.speed = 0.7f;
            }
        }
        if (GameManagerScript.GetStageNumber() == 2)
        {
            if (GameManagerScript.GetWaveCount() == 6)
            {
                _Animator.speed = 0.7f;
            }
        }
        if (GameManagerScript.GetStageNumber() == 3)
        {
            if (GameManagerScript.GetWaveCount() == 6)
            {
                _Animator.speed = 0.7f;
            }
        }

        if (GameManagerScript.GetSpeedUpFlg())
        {
            _Animator.speed = 1.2f;
        }
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);

    }

    void Jump()
    {
        if (!GameManagerScript.GetPerformance())  // 演出中ではない
        {
            // 右クリック
            if (RightClickUse && Input.GetMouseButtonDown(1))
            {
                RightClickCheck = true;
            }

            // 左クリック時ジャンプ
            if (Input.GetMouseButtonDown(0) || (RightClickUse && Input.GetMouseButtonDown(1)))
            {
                if (!GameManagerScript.GetPlayerJump())
                {
                    // 下の壁にいる時
                    if (!RightClickNow &&
                        GameManagerScript.GetPlayerWallWhich() == 0) Up();

                    // 上の壁にいる時
                    if (!RightClickNow &&
                        GameManagerScript.GetPlayerWallWhich() == 1) Down();
                }
            }
        }

        // 右クリックされたら着地の遅延を行う
        if (RightClickCheck)
        {
            ClickTime += 0.1f;
            if (ClickTime >= 0.7f) RightClickNow = true;
        }

        transform.localScale = Scale;
    }

    //上にジャンプ
    void Up()
    {
        GameManagerScript.SetPlayerDir(1);
        // 上方向に力を与える
        R2d.AddForce(Vector2.up * JumpSpeed*Time.deltaTime);
        // y軸のスケールを変更し向きを変える
        Scale.y = -SaveScale.y;
        // ジャンプ中
        GameManagerScript.SetPlayerJump(true);
    }
    //下にジャンプ
    void Down()
    {
        GameManagerScript.SetPlayerDir(0);
        // 下方向に力を与える
        R2d.AddForce(Vector2.down * JumpSpeed*Time.deltaTime);
        Scale.y = SaveScale.y;
        GameManagerScript.SetPlayerJump(true);
    }

    void TwoJump()
    {
        // 右クリックされたら
        if (RightClickNow)
        {
            // 当たり判定を外す
            Bc2d.enabled = false;
            // 時間を止める
            Time.timeScale = 0.0f;
            // 透明度を下げる
            Alpha -= 0.1f;
            // 着地時遅延のタイマー起動
            DelayTimer++;
        }

        // 設定した着地時の遅延時間に達したら
        if (DelayTimer >= DelayTime)
        {
            // 時間を元に戻す
            Time.timeScale = 1.0f;
            // 当たり判定を付ける
            Bc2d.enabled = true;
            // 透明度を元に戻す
            Alpha = 1.0f;

            // 壁に触れたらタイマーのリセット
            if (!RightClickNow)
            {
                DelayTimer = 0;
            }
        }
    }

    // 壁に触れたら
    void ClickJumpFlgCheck()
    {
        // ジャンプ中ではない
        GameManagerScript.SetPlayerJump(false);
        // クリックされていない
        RightClickNow = false;
        // 右クリックされていない
        RightClickCheck = false;
        // 着地時の遅延のタイマーをリセット
        ClickTime = 0;
    }
    void AlphaChange()
    {
        if (GameManagerScript.GetGolaHit())
        {
            Alpha -= 0.1f;
        }
        //Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
    }
    void OnTriggerEnter2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "UpWall")
        {
            GameManagerScript.SetPlayerWallWhich(1);// 上の壁にいる
            ClickJumpFlgCheck();
        }
        if (C2d.transform.tag == "DownWall")
        {
            GameManagerScript.SetPlayerWallWhich(0);// 下の壁にいる
            ClickJumpFlgCheck();
        }
    }

    void OnTriggerExit2D(Collider2D C2d)
    {

        if (C2d.transform.tag == "UpWall")
        {
            if (GameManagerScript.GetPlayerGoalFlg())
            {
                R2d.gravityScale = 0.0f;
            }
            if (!GameManagerScript.GetPlayerGoalFlg())
            {
                R2d.gravityScale = -10.5f;
            }
        }
        if (C2d.transform.tag == "DownWall")
        {
            if (GameManagerScript.GetPlayerGoalFlg())
            {
                R2d.gravityScale = 0.0f;
            }
            if (!GameManagerScript.GetPlayerGoalFlg())
            {
                R2d.gravityScale = 10.5f;
            }
        }
    }
}
