using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour {
    public GameObject LandingEffect;
    public GameObject JumpEffect;
    public GameObject RightClickEffect;
    public bool flg;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    int DoubleClickEffectTime;
    PlayerJumpScript playerJump;
    // Use this for initialization
    void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();
        DoubleClickEffectTime = 0;
    }

    // Update is called once per frame
    void Update () {
        if (!GameManagerScript.GetPlayerAlive()) return;

        // 左クリックされ且つ演出中ではなかったら
        if (Input.GetMouseButtonDown(0)&&!GameManagerScript.GetPerformance())
        {
            // ジャンプ中のエフェクトを生成
            GameObject JumpEf = Instantiate(JumpEffect, transform.position, Quaternion.identity);
            //0.1秒後に削除
            Destroy(JumpEf, 0.1f);
        }

        // 右クリックされたら
        if (FindObjectOfType<PlayerJumpScript>().RightClickNow)
        {
            // ダブルクリック時のエフェクトを生成するための
            // タイマーを起動
            DoubleClickEffectTime++;
        }
        else
        {
            DoubleClickEffectTime = 0;
        }

        if (DoubleClickEffectTime == 1)
        {
            audioSource.PlayOneShot(audioClip[1]);
            // 右クリック時のエフェクト生成
            GameObject DoubleClickEf = Instantiate(RightClickEffect, transform.position, Quaternion.identity);
            // 0.3秒後に削除
            Destroy(DoubleClickEf, 0.3f);
        }

        // 着地時の遅延時間が35になったら
        if (FindObjectOfType<PlayerJumpScript>().DelayTimer == 35)
        {
            audioSource.PlayOneShot(audioClip[1]);
            // 右クリック時の時と同じエフェクトを生成
            #region 説明
            // 右クリックするとPlayerは異次元にワープする様な見た目にしているので
            // ワープゲートが出てからPlayerをそのワープゲートから出てきているように見せる
            #endregion
            GameObject DoubleClickEf = Instantiate(RightClickEffect, transform.position, Quaternion.identity);
            // 0.3秒後に削除
            Destroy(DoubleClickEf, 0.3f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Effect")
        {
            audioSource.PlayOneShot(audioClip[0]);

            // 着地時のエフェクトを生成
            GameObject LandingEf = Instantiate(LandingEffect, transform.position, Quaternion.identity);
            // 0.3秒後に削除
            Destroy(LandingEf, 0.3f);

            // カメラシェイク
            GameObject shake = GameObject.Find("Main Camera");
            flg = shake.GetComponent<ShakeCamera>().GetShakeFlg();
            if (!flg) shake.GetComponent<ShakeCamera>().CatchShake();
      
        }
    }

}
