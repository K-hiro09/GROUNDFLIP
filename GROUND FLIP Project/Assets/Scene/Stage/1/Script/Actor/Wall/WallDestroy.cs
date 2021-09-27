using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    private GameObject DestroyPos;
    private GameObject Parent; //親のオブジェクトを取得

    // Use this for initialization
    void Start()
    {
        DestroyPos = GameObject.Find("DestroyPos");
        Parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= DestroyPos.transform.position.x)
        {
            Destroy(Parent);
            Destroy(gameObject);//念のため
        }
    }
}
