using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroy : MonoBehaviour {
    private GameObject DestroyPos;
    private Vector3 Pos;
	// Use this for initialization
	void Start () {
        DestroyPos = GameObject.Find("DestroyPos");
        Pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= DestroyPos.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
