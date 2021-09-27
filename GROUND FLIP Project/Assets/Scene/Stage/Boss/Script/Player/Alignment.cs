using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour
{
    private SpriteRenderer Sp;
    private GameObject Player;
    // Use this for initialization
    void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
        Sp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (FindObjectOfType<BossState>().RockOn)
        //{
        //    Sp.enabled = true;
        //    transform.parent = Player.transform;
        //    transform.position = Player.transform.position;
        //}
        //else
        //{
        //    //Sp.enabled = false;
        //    transform.parent = null;
        //}

        //if (FindObjectOfType<BossState>().Hit)
        //{
        //    Sp.enabled = false;
        //}
    }
}
