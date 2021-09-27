using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAlphaCheck : MonoBehaviour
{
    private Animator Anima;
    private SpriteRenderer Sp;
    private float Alpha;
    private int Count;
    public bool End;
    // Use this for initialization
    void Start()
    {
        Anima = GetComponent<Animator>();
        Sp = GetComponent<SpriteRenderer>();
        Anima.enabled = false;
        Sp.enabled = false;
        End = false;
        Count = 0;
        Alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Anima.updateMode = AnimatorUpdateMode.UnscaledTime;
        if (Warning.GetWartingTimer() >= 90)
        {
            Anima.enabled = true;
            Sp.enabled = true;
        }
        if (Count >= 5)
        {
            Anima.enabled = false;
            End = true;
            Alpha -= 0.1f;
        }
        if (Alpha <= 0.0f)
        {
            Destroy(gameObject);
        }
        Sp.color = new Color(0.0f, 0.0f, 0.0f, Alpha);
    }

    void AlphaCount()
    {
        Count++;
    }
}
