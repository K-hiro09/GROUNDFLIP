using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    private Vector3 Pos;
    private float Speed;
    private GameObject GoalPos;
    private bool limtFlg;
    // Use this for initialization
    void Start () {
        Speed = 10.0f;
        limtFlg = false;

        GoalPos = GameObject.Find("GoalPos");
    }
	
	// Update is called once per frame
	void Update () {
        Pos = transform.position;

        if (Pos.x <= GoalPos.transform.position.x)
        {
            Pos = GoalPos.transform.position;
            limtFlg = true;
        }

        if (GameManagerScript.GetPlayerAlive())
        {
            Pos.x -= Speed*Time.deltaTime;
        }
        if(!limtFlg)transform.position = Pos;
    }
}
