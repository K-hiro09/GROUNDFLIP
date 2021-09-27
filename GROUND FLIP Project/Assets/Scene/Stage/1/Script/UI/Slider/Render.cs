using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Render : MonoBehaviour {
    private Image _Image;
	// Use this for initialization
	void Start () {
        _Image = GetComponent<Image>();
        _Image.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        //スピードアップの演出中非表示
        if (GameManagerScript.GetPerformance())
        {
            _Image.enabled = false;
        }
        else
        {
            _Image.enabled = true;
        }
    }
}
