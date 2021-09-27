using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {
    private SpriteRenderer Sp;
    private Vector3 Pos;
    private GameObject Target;
    private float Speed;
    private float Alpha;
    private int AlphaTimer;
    PlayerGoal playerGoal = new PlayerGoal();
    // Use this for initialization
    void Start () {
        Sp = GetComponent<SpriteRenderer>();
        Pos = transform.position;

        Target = GameObject.Find("StageClearPos");

        Sp.enabled = false;

        Speed = 5.0f;

        AlphaTimer = 0;
        Alpha = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManagerScript.GetGolaHit())
        {
            Sp.enabled = true;
            Pos.x -= Speed;
            AlphaTimer++;
            if (Target.transform.position.x >= Pos.x)
            {
                Pos.x = Target.transform.position.x;
            }
        }
        AlphaChange();
        transform.position = Pos;
	}

    void AlphaChange()
    {
        #region Timer
        switch (AlphaTimer)
        {
            case 10:
                Alpha = 0.5f;
                break;
            case 15:
                Alpha = 0.65f;
                break;
            case 20:
                Alpha = 0.7f;
                break;
            case 25:
                Alpha = 0.75f;
                break;
            case 30:
                Alpha = 0.8f;
                break;
            case 35:
                Alpha = 0.9f;
                break;
            case 40:
                Alpha = 1.0f;
                break;
            case 45:
                Alpha = 0.9f;
                break;
            case 50:
                Alpha = 0.8f;
                break;
            case 55:
                Alpha = 0.75f;
                break;
            case 60:
                Alpha = 0.7f;
                break;
            case 65:
                Alpha = 0.65f;
                break;
            case 70:
                Alpha = 0.5f;
                AlphaTimer = 0;
                break;
        }
        #endregion
        Sp.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
    }

}
