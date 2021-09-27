using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotImpactTimeScale : MonoBehaviour
{
    private Animator _Animation;

    // Use this for initialization
    void Start()
    {
        _Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // タイムスケール無効
        _Animation.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}
