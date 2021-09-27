using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAlpha : MonoBehaviour
{
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float changeBlue = 1.0f;
    float chageAlpha = 0.1f;

    int AlphaTimer;
    void Start()
    {
        AlphaTimer = 0;
    }

    void Update()
    {
        AlphaTimer++;

        switch (AlphaTimer)
        {
            case 10:
                chageAlpha = 0.15f;
                break;
            case 15:
                chageAlpha = 0.25f;
                break;
            case 20:
                chageAlpha = 0.3f;
                break;
            case 25:
                chageAlpha = 0.35f;
                break;
            case 30:
                chageAlpha = 0.4f;
                break;
            case 35:
                chageAlpha = 0.45f;
                break;
            case 40:
                chageAlpha = 0.5f;
                break;
            case 45:
                chageAlpha = 0.45f;
                break;
            case 50:
                chageAlpha = 0.4f;
                break;
            case 55:
                chageAlpha = 0.35f;
                break;
            case 60:
                chageAlpha = 0.3f;
                break;
            case 65:
                chageAlpha = 0.25f;
                break;
            case 70:
                chageAlpha = 0.2f;
                break;
            case 75:
                chageAlpha = 0.15f;
                AlphaTimer = 0;
                break;
        }

        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, changeBlue, chageAlpha);
    }
}