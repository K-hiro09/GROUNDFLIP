using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBgm : MonoBehaviour
{
    private AudioSource Audio;
    // Use this for initialization
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (FindObjectOfType<BodyRender>().BodyOk)
        //{
        //    Audio.enabled = true;
        //}
        if (!GameManagerScript.GetPlayerAlive())
        {
            Destroy(gameObject);
        }
    }
}
