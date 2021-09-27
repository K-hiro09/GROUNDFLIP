using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootEffect : MonoBehaviour {
    ParticleSystemRenderer Pr;
	// Use this for initialization
	void Start () {
        Pr = GetComponent<ParticleSystemRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //パーティクルの表示非表示

        //Playerジャンプ時
        if (!GameManagerScript.GetPlayerJump())
        {
            Pr.enabled = true;
        }
        else
        {
            Pr.enabled = false;
        }
        //Playerゴール時
        if (GameManagerScript.GetPlayerGoalFlg())
        {
            Pr.enabled = false;
        }
        //Player死亡時
        if (!GameManagerScript.GetPlayerAlive())
        {
            Pr.enabled = false;
        }
    }
}
