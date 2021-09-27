using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLane : MonoBehaviour {
    public float ScrollSpeed = 0.01f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Warning.GetWartingTimer() >= 90)
        {
            transform.Translate(ScrollSpeed, 0.0f, 0);
        }
    }
}
