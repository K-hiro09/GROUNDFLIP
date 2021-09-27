using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFont : MonoBehaviour
{
    public GameObject[] Font;
    public Transform[] FontPos;
    private Vector3 VecS, VecT, VecA, VecG, VecE, VecOne;
    private Vector3 Spos, Tpos, Apos, Gpos, Epos, Onepos;
    private float MoveSpeed;
    private bool EndFlg;
    public int StopTime;

    //Use this for initialization
    void Start()
    {
        Spos = Font[0].transform.position;
        Tpos = Font[1].transform.position;
        Apos = Font[2].transform.position;
        Gpos = Font[3].transform.position;
        Epos = Font[4].transform.position;
        Onepos = Font[5].transform.position;
        MoveSpeed = 2.5f * 2;
        EndFlg = false;
    }

    //Update is called once per frame
    void VecAsk()
    {
        //各スプライトを左に移動
        VecS = FontPos[0].transform.position - Spos;
        VecS = VecS.normalized;
        Spos += new Vector3(VecS.x * MoveSpeed, VecS.y * 0.0f, 0.0f);

        if (Spos.x <= -3.0f)
        {
            VecT = FontPos[1].transform.position - Tpos;
            VecT = VecT.normalized;
            Tpos += new Vector3(VecT.x * MoveSpeed, VecT.y * 0.0f, 0.0f);
        }

        if (Tpos.x <= -3.0f)
        {
            VecA = FontPos[2].transform.position - Apos;
            VecA = VecA.normalized;
            Apos += new Vector3(VecA.x * MoveSpeed, VecA.y * 0.0f, 0.0f);
        }

        if (Apos.x <= -2.0f)
        {
            VecG = FontPos[3].transform.position - Gpos;
            VecG = VecG.normalized;
            Gpos += new Vector3(VecG.x * MoveSpeed, VecG.y * 0.0f, 0.0f);
        }

        if (Apos.x <= -2.0f)
        {
            VecE = FontPos[4].transform.position - Epos;
            VecE = VecE.normalized;
            Epos += new Vector3(VecE.x * MoveSpeed, VecE.y * 0.0f, 0.0f);
        }

        if (Apos.x <= -2.0f)
        {
            VecOne = FontPos[5].transform.position - Onepos;
            VecOne = VecOne.normalized;
            Onepos += new Vector3(VecOne.x * MoveSpeed, VecOne.y * 0.0f, 0.0f);
        }
    }

    void Update()
    {
        VecAsk();

        if (GameManagerScript.GetGameTimer() >= StopTime)
        {
            Spos.x -= MoveSpeed + 3.0f;
            Tpos.x -= MoveSpeed + 3.0f;
            Apos.x -= MoveSpeed + 3.0f;
            Gpos.x -= MoveSpeed + 3.0f;
            Epos.x -= MoveSpeed + 3.0f;
            Onepos.x -= MoveSpeed + 3.0f;
        }

        Font[0].transform.position = Spos;
        Font[1].transform.position = Tpos;
        Font[2].transform.position = Apos;
        Font[3].transform.position = Gpos;
        Font[4].transform.position = Epos;
        Font[5].transform.position = Onepos;

    }
}
