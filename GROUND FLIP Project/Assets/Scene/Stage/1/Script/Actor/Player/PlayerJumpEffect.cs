using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpEffect : MonoBehaviour
{
    SpriteRenderer Sp;
    Vector3 Scale;
    private float Alpha;
    PlayerJumpScript playerJump;
    // Use this for initialization
    void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
        Scale = transform.localScale;
        Alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Scale.y += 0.35f;
        Scale.x += 0.05f;
        Alpha -= 0.01f;
        transform.localScale = Scale;
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
    }
}
