using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    #region Variable
    private SpriteRenderer Sp;
    private CircleCollider2D Cc2D;
    private Animator _Animator;
    private int ScaleTimer;
    private bool AreaOutCheck;
    private bool AreaOutStar;
    private Vector3 Scale;
    private Vector3 ScaleSave;
    private float Alpha;
    private float AnimeFrame;
    private Vector3 Vec;
    private GameObject EvaluationPos;
    private int AddScoreNum;
    private GameObject Player;

    public bool Check;
    //bool f;

    AudioSource _AudioSource;
    public List<AudioClip> _AudioClip = new List<AudioClip>();
    public bool AreaFlg;
    public GameObject StarScore;
    public GameObject[] Evaluation;
    #endregion
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        AddScoreNum = 0;
        _Animator = GetComponent<Animator>();
        _AudioSource = gameObject.AddComponent<AudioSource>();
        Sp = GetComponent<SpriteRenderer>();
        Cc2D = GetComponent<CircleCollider2D>();

        EvaluationPos = GameObject.Find("EvaluationPos");

        AreaFlg = false;
        AreaOutCheck = false;
        AreaOutStar = false;

        Scale = transform.localScale;
        ScaleSave = Scale;
        ScaleTimer = 0;
        Alpha = 1.0f;
    }

    void Update()
    {
        GameManagerScript.SetAreaScorePlus(AddScoreNum);
        Delete();
        AnimationScore();
        StarScoreAdd();
        AreaIn();
        AreaOut();
        transform.localScale = Scale;
    }

    void Delete()
    {
        if (transform.position.x <= (Player.transform.position.x - 5.0f))
        {
            Alpha -= 0.1f;
        }
    }

    void StarScoreAdd()
    {
        // スコア加算エリア内からでたらスコアテキストに吸い込まれる星屑生成
        if (AreaOutStar)
        {
            Instantiate(StarScore, transform.position, Quaternion.identity);
            AreaOutStar = false;
        }
    }

    // どのアニメーションが再生されているかの取得
    bool AnimeInfo(int layer, string name)
    {
        //何番目のレイヤーの何と言う名前か。
        return _Animator.GetCurrentAnimatorStateInfo(layer).IsName(name);
    }

    void AnimationScore()
    {
        if (!Check)
        {
            // Playerがスコア加算エリア内に居たら
            // アニメーション再生
            if (AreaFlg)
            {
                if (AnimeInfo(0, "Area"))
                {
                    AddScoreNum = 1;
                    _Animator.SetBool("0from1", true);
                }
                // スコア加算一段階目のアニメ
                if (AnimeInfo(0, "AreaGauge1"))
                {
                    AddScoreNum = 1;
                    _Animator.SetBool("1from2", true);
                }

                // スコア加算二段階目のアニメ
                else if (AnimeInfo(0, "AreaGauge2"))
                {
                    AddScoreNum = 2;
                    _Animator.SetBool("2from3", true);
                }

                // スコア加算アニメーションがマックス時にマックスの値を加算したいから
                // 二段階目～マックス時の間にアニメーションを入れる
                else if (AnimeInfo(0, "AreaGauge3"))
                {
                    _Animator.SetBool("3fromMax", true);
                }

                // スコア加算マックス時のアニメ
                else if (AnimeInfo(0, "AreaGaugeMax"))
                {
                    AddScoreNum = 3;
                    AreaOutCheck = true;
                }
            }
        }

    }
    #region エリアの出入り
    void AreaIn()
    {
        Sp.color = new Color(1.0f, 1.0f, 0, Alpha);
        // エリアの拡縮
        if (AreaFlg)
        {
            ScaleTimer++;
        }
        else ScaleTimer = 0;
        if (ScaleTimer >= 1)
        {
            Scale.x += 0.005f;
            Scale.y += 0.005f;
        }
    }

    void AreaOut()
    {
        //プレイヤーがスコア加算エリア内から出たら
        if (AreaOutCheck)
        {
            Scale.x += 0.15f;
            Scale.y += 0.15f;
            Alpha -= 0.1f;
            Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
            Cc2D.enabled = false;
        }
        if (Alpha <= 0.0f) Destroy(gameObject);

    }
    #endregion

    #region 当たり判定
    private void OnTriggerEnter2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "DestroyArea")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "Player")
        {
            AreaFlg = true;
        }
    }

    private void OnTriggerExit2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "Player")
        {
            // スコア加算エリア内から出たとき
            if (AddScoreNum == 1) //一段階目
            {
                // Nice
                FindObjectOfType<Score>().AddScore(100);
                Instantiate(Evaluation[0], EvaluationPos.transform.position, Quaternion.identity);
            }
            if (AddScoreNum == 2)　//二段階目
            {
                // Good
                FindObjectOfType<Score>().AddScore(300);
                Instantiate(Evaluation[1], EvaluationPos.transform.position, Quaternion.identity);
            }
            if (AddScoreNum == 3) //三段階目
            {
                // Great!
                FindObjectOfType<Score>().AddScore(500);
                Instantiate(Evaluation[2], EvaluationPos.transform.position, Quaternion.identity);
            }
            _AudioSource.PlayOneShot(_AudioClip[1]);
            AreaOutCheck = true;
            AreaOutStar = true;
            AreaFlg = false;
        }
    }
    #endregion
}
