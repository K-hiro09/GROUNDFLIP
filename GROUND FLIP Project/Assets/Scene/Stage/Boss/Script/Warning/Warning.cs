using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    AudioSource AudioSource;
    public List<AudioClip> AudioClip = new List<AudioClip>();
    static private int WarningTimer;
    static public int GetWartingTimer() { return WarningTimer; }
    // Use this for initialization
    void Start()
    {
        AudioSource = gameObject.AddComponent<AudioSource>();
        WarningTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WarningTimer++;
        if (WarningTimer == 90) AudioSource.PlayOneShot(AudioClip[0]);
        //if (FindObjectOfType<WarningAlphaCheck>().End) Destroy(gameObject);
    }
}
