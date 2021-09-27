using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    private Vector3 Vec;
    private GameObject Target;
    private SpriteRenderer Sp;
    private float Speed;
    private float Alpha;
    public bool GoalHit;
    private int Wait;
    private int SceneChangeTimer;
    private int SEtimer;

    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    // Use this for initialization
    void Start()
    {
        Target = GameObject.Find("GoalPos");
        Sp = GetComponent<SpriteRenderer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        Speed = 0.3f;
        Alpha = 0.5f;
        GoalHit = false;
        SceneChangeTimer = 0;
        Wait = 0;
        SEtimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InhaleRotation();
        SceneChange();
    }

    // 回転しながらゴールに吸い込まれる
    void InhaleRotation()
    {

        //各ステージゴール時
        if (GameManagerScript.GetWaveCount() == 17 && GameManagerScript.GetStageNumber() == 1)
        {
            Wait++;
        }
        if (GameManagerScript.GetWaveCount() == 12 && GameManagerScript.GetStageNumber() == 2)
        {
            Wait++;
        }

        if (GameManagerScript.GetWaveCount() == 10 && GameManagerScript.GetStageNumber() == 3)
        {
            Wait++;
        }

        if (Wait >= 160)
        {
            GameManagerScript.SetPlayerGoalFlg(true);
        }

        if (GameManagerScript.GetPlayerGoalFlg())
        {
            SEtimer++;
            Vec = Target.transform.position - transform.position;
            Vec = Vec.normalized;
            transform.position += new Vector3(Vec.x * Speed, Vec.y * Speed, 0.0f);
            transform.Rotate(0.0f, 0.0f, 10.0f);
        }
        if (SEtimer == 1) audioSource.PlayOneShot(audioClip[0]);
    }

    void SceneChange()
    {
        if (GoalHit) SceneChangeTimer++;
        if (SceneChangeTimer > 60 * 3) FadeManager.FadeOut(1);
    }

    void OnTriggerEnter2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "Goal") GoalHit = true;
    }
}
