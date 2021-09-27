using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEye : MonoBehaviour
{
    private Animator Anima;
    private SpriteRenderer Sp;
    private int Count;
    public bool EyeFlashingOk;
    private GameObject WarningSet;
    private int Wait;
    private float Alpha;
    // Use this for initialization
    void Start()
    {
        Anima = GetComponent<Animator>();
        Sp = GetComponent<SpriteRenderer>();
        WarningSet = GameObject.Find("WarningSet");
        Anima.enabled = false;
        Sp.enabled = false;
        EyeFlashingOk = false;
        Count = 0;
        Wait = 0;
        Alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (WarningSet == null)
        {
            Wait++;
        }
        if (Wait >= 60)
        {
            Sp.enabled = true;
            Anima.enabled = true;
        }
        if (Count >= 3)
        {
            EyeFlashingOk = true;
            Anima.enabled = false;
            Sp.enabled = true;
            Alpha += 0.1f;
            if (Alpha >= 1.0f)
            {
                Alpha = 1.0f;
            }
            Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
        }
    }

    void EyeFlashingCout()
    {
        Count++;
    }
}
