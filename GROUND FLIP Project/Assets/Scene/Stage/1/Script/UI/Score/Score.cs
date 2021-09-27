using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    private static int ScoreNum;
    private int FontSize;
    private bool FontSizeFlg;

    public void AddScore(int num)
    {
        ScoreNum = ScoreNum + num;
    }

    // Use this for initialization
    void Start()
    {
        ScoreNum = 0;
        FontSize = ScoreText.fontSize;
        ScoreText.text = "Score:";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + ScoreNum;

        GameManagerScript.SetScoreNum(ScoreNum);
        ScoreText.fontSize = FontSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            GameManagerScript.SetHitScoreStar(true);
            if (!FontSizeFlg) StartCoroutine(TextEnlargement());
        }
    }

    // スコアテキストの拡縮
    IEnumerator TextEnlargement()
    {
        int TextSize = FontSize;
        FontSizeFlg = true;
        while (FontSize < 80)
        {
            FontSize += 20;
            yield return null;
        }
        while (FontSize > TextSize)
        {
            FontSize -= 20;
            yield return null;
        }
        FontSize = TextSize;
        FontSizeFlg = false;
    }

}
