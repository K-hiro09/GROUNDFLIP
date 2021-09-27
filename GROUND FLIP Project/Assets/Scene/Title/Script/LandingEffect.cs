using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingEffect : MonoBehaviour
{
    private SpriteRenderer Sp;
    private float Alpha;
    private Vector3 Scale;
    private Quaternion Rotation;
    // Use this for initialization
    void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
        Alpha = 1.0f;
        Scale = transform.localScale;
        Rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.GetPlayerWallWhich() == 1)
        {
            Rotation.z = 180.0f;
        }
        else Rotation.z = 0.0f;

        Alpha -= 0.1f;
        Scale.x += 0.3f;

        transform.localScale = Scale;
        transform.rotation = Rotation;
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
    }
}
