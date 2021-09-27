using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectAnim : MonoBehaviour
{
    private Animator Anim;
    [SerializeField]
    private bool Up;
    public GameObject Effect;
    private Vector3 Player;
    private Vector3 EfeScale;
    [SerializeField]
    private Mouse mouse;

    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
        EfeScale = Effect.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Player = transform.position;

        if (mouse.ChoiceDown && Up)
        {
            AnimMove();
        }
        else if (mouse.ChoiceUp && !Up)
        {
            AnimMove();
        }

        if (!mouse.ChoiceDown && Up)
        {
            AnimWait();
        }
        else if (!mouse.ChoiceUp && !Up)
        {
            AnimWait();
        }
    }

    void AnimMove()
    {
        Anim.SetBool("Move", true);

        if (Up)
        {
            //着地時のエフェクトを生成
            GameObject LandingEf = Instantiate(Effect, Player, Quaternion.identity);
            Destroy(LandingEf, 0.1f);
        }

        if (!Up)
        {
            GameObject LandingEf = Instantiate(Effect, Player, Quaternion.identity);
            Destroy(LandingEf, 0.1f);
        }
    }
    void AnimWait()
    {
        Anim.SetBool("Wait", true);
        Anim.SetBool("Move", false);
    }

    void AnimEnd()
    {
        mouse.ChoiceDown = false;
        mouse.ChoiceUp = false;
    }
}
