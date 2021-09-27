using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour {
    private SpriteRenderer Sp;
    private Vector3 Scale;
    private bool Click;
    private float Alpha;
	// Use this for initialization
	void Start () {
        Sp = GetComponent<SpriteRenderer>();
        Sp.enabled = false;
        Scale = transform.localScale;
        Click = false;
        Alpha = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0)) Click = true;
        if (Click)
        {
            // クリックされたら描画
            Sp.enabled = true;
            // 拡大
            Scale.x += 0.1f;
            Scale.y += 0.1f;
            Scale.z += 0.1f;
            // 回転
            transform.Rotate(0.0f, 0.0f, 15.0f);
            // 透明度
            Alpha -= 0.05f;
            Destroy(gameObject, 0.5f);
        }

        transform.localScale = Scale;
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);

    }
}
