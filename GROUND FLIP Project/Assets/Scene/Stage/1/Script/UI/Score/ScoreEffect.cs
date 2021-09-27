using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEffect : MonoBehaviour {
    public GameObject Effect;
    private int EffectTimer;
    void Start()
    {
        EffectTimer = 0;
    }
	// Update is called once per frame
	void Update () {
        EffectTimer++;
        if (EffectTimer == 1)
        {
            // エフェクト生成
            GameObject Ef = Instantiate(Effect, transform.position, Quaternion.identity);
            //0.1秒後に削除
            Destroy(Ef, 0.1f);
        }
    }
}
