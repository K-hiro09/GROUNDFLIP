using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Emitter : MonoBehaviour
{
    public GameObject[] waves;
    //現在のWave
    private int currentWave;

    IEnumerator Start()
    {
        // Waveが存在しなければ終了
        if (waves.Length == 0)
        {
            yield break;
        }

        while (true)
        {
            //Wave作成
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            //WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            //Waveの子要素のEnemyが全て削除されるまで待機
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(wave);
            //格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }

        }

    }

    void Update()
    {
        //GameManagerScript.SetWaveCount(currentWave);
        //GameManagerScript.SetMaxWaveCount(waves.Length);
    }

}
