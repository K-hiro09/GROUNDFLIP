using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVSObjectScript : MonoBehaviour
{
    public GameObject DeadEffectObj;
    private SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D C2d)
    {
        // 障害物に触れると
        if (C2d.transform.tag == "Obstacle" && !GameManagerScript.GetPlayerContinuDead())
        {
            // 死亡エフェクト生成
            GameObject Obj = Instantiate(DeadEffectObj, transform.position, Quaternion.identity) as GameObject;
            Destroy(Obj, 1.0f);
            // プレイヤー生死判定のフラグをfalse(死)に
            GameManagerScript.SetPlayerAlive(false);
            // プレイヤーを消す
            //Destroy(gameObject);
            sp.enabled = false;
        }
    }

}
