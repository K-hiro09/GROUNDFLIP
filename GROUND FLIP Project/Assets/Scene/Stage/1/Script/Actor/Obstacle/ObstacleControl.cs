using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {
    public float Speed;
    private Vector3 Pos;
    private float Dist;
    GameObject Player;
    GameObject InsPos;
    public GameObject[] GuideObj;
    private SpriteRenderer Sp;
    private GameObject AreaObj;

	// Use this for initialization
	void Start () {
        Pos = transform.position;
        Player = GameObject.Find("Player");
        InsPos = GameObject.Find("InsPos");
        AreaObj = GameObject.FindWithTag("Area");
        Sp = GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {
        Move();
    }
    void Move()
    {
        if (GameManagerScript.GetPlayerAlive())
        {
            Pos.x -= Speed;
            if (GameManagerScript.GetGameTimer() > 1990&&GameManagerScript.GetPlayerAlive())
            {
                Speed = 0.2f;
            }
        }
        if (!GameManagerScript.GetPlayerAlive())
        {
            Speed = 0.0f;
        }
        if (GameManagerScript.GetGameTimer() > 4000)
        {
            Destroy(gameObject);
        }
        transform.position = Pos;
        if (GameManagerScript.GetPerformance()) Destroy(gameObject);
        Destroy(gameObject, 7.0f);
    }
    private void OnTriggerStay2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "Player")
        {
            Sp.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D C2d)
    {
        if (C2d.transform.tag == "Player")
        {
            Sp.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
