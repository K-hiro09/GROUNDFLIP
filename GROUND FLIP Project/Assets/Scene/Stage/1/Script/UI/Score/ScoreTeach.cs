using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTeach : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Pos;
    private float Dist;
    private Animator _Animator;
    private SpriteRenderer Sp;
    private float Alpha;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        _Animator = GetComponent<Animator>();
        Sp = GetComponent<SpriteRenderer>();

        _Animator.enabled = false;
        Sp.enabled = false;
        Alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        DistMethod();
        AlphaMethod();
    }

    void DistMethod()
    {
        Pos = transform.position;
        Dist = Vector3.Distance(Pos, Player.transform.position);

        //Playerと一定距離になるとアニメ再生
        if (Dist <= 16.0f && GameManagerScript.GetPlayerWallWhich() == 0)
        {
            _Animator.enabled = true;
            Sp.enabled = true;
        }

        else if (Dist <= 16.5f && GameManagerScript.GetPlayerWallWhich() == 1)
        {
            _Animator.enabled = true;
            Sp.enabled = true;
        }
    }

    void AlphaMethod()
    {
        if (GameManagerScript.GetHitScoreStar())
        {
            Alpha -= 0.1f;
        }
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
    }

}
