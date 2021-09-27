using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Way : MonoBehaviour {

    private float Max;            //もとの数
    private float Now;            //くらべる数
    private float Proportion;     //割合
    private float Percent;        //百分率

    private Slider _Slider;
    // Use this for initialization
    void Start () {
        _Slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        Max = GameManagerScript.GetMaxAudioTime();
        Now = GameManagerScript.GetNowAudioTime();
        _Slider.maxValue = Max;
        Proportion = Now / Max;
        Percent = Proportion * Max;
        _Slider.value = Percent;
        if (_Slider.value >= _Slider.maxValue)
        {
            _Slider.value = _Slider.maxValue;
        }
    }
}
