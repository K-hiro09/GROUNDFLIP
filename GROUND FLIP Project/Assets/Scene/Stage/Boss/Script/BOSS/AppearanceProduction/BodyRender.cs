using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRender : MonoBehaviour {
    private SpriteRenderer Sp;
    private float Alpha;
    public bool BodyOk;
    // Use this for initialization
    void Start () {
        Sp = GetComponent<SpriteRenderer>();
        Sp.enabled = false;
        Alpha = 0.0f;
        BodyOk = false;
    }

    // Update is called once per frame
    void Update () {
        //if (FindObjectOfType<RedEye>().EyeFlashingOk)
        //{
        //    Sp.enabled = true;
        //    BodyOk = true;
        //    Alpha += 0.01f;
        //}
        if (Alpha >= 1.0f)
        {
            Alpha = 1.0f;
        }
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
	}
}
