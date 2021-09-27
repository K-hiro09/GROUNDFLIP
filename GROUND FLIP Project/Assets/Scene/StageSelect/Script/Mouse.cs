using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mouse : MonoBehaviour
{
    private Vector3 Pos;
    private bool Stage1;
    private bool Stage2;
    private bool Stage3;
    private bool Boss;
    [System.NonSerialized]
    public bool ChoiceDown, ChoiceUp;
    [System.NonSerialized]
    public bool Stage1from2, Stage2from1, Stage2from3, Stage3from4, Stage3from2, Stage4from3;

    AudioSource _AudioSource;
    public List<AudioClip> _AudioClip = new List<AudioClip>();
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;
        FadeManager.FadeIn();
        Stage1 = false;
        Stage2 = false;
        Stage3 = false;

        ChoiceDown = false;
        ChoiceUp = false;

        Stage1from2 = false;
        Stage2from1 = false;
        Stage2from3 = false;
        Stage3from4 = false;
        Stage3from2 = false;
        Stage4from3 = false;

        _AudioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StageStart();
        StageChoice();
    }

    void StageChoice()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Pos);

        //-3.4 -0.5
        // -1.9 -1.9
        //Stage1から2に変更
        if (worldPos.y <= -0.5f && worldPos.y >= -1.9f)
        {
            if (worldPos.x >= -3.4f && worldPos.x <= -1.9f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChoiceDown = true;
                    Stage1from2 = true;
                    SelectSE();
                }
            }
        }
        // -3.4 -6.4
        // -2.1 -7.8
        //Stage2から1に変更
        if (worldPos.y <= -6.4f && worldPos.y >= -7.8f)
        {
            if (worldPos.x >= -3.4f && worldPos.x <= -2.1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChoiceUp = true;
                    Stage2from1 = true;
                    SelectSE();
                }
            }
        }

        // -3.4 -10.5
        // -2.3 -11.6
        //Stage2から3に変更
        if (worldPos.y <= -10.5f && worldPos.y >= -11.6f)
        {
            if (worldPos.x >= -3.4f && worldPos.x <= -2.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChoiceDown = true;
                    Stage2from3 = true;
                    SelectSE();
                }
            }
        }

        // -3.4 -16.7
        // -2.3 -18.6
        //Stage3から2に変更
        if (worldPos.y <= -16.7f && worldPos.y >= -18.6f)
        {
            if (worldPos.x >= -3.4f && worldPos.x <= -2.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChoiceUp = true;
                    Stage3from2 = true;
                    SelectSE();
                }
            }
        }

        // -3.4 -20.5
        // -2.3 -22.2
        //Stage3から4(Boss)に変更
        if (worldPos.y <= -20.5f && worldPos.y >= -22.2f)
        {
            if (worldPos.x >= -3.4f && worldPos.x <= -2.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChoiceDown = true;
                    Stage3from4 = true;
                    SelectSE();
                }
            }
        }


        // -3.4 -25.9
        // -2.3 -27.6
        //Stage4から3に変更
        if (worldPos.y <= -25.9f && worldPos.y >= -27.6f)
        {
            if (worldPos.x >= -3.4f && worldPos.x <= -2.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChoiceUp = true;
                    Stage4from3 = true;
                    SelectSE();
                }
            }
        }

    }

    void StageStart()
    {

        Pos = Input.mousePosition;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Pos);
        //1.8 -1.8
        //4.3 -4.1
        //Stage1スタート
        if (worldPos.y <= -1.8f && worldPos.y >= -4.1f)
        {
            if (worldPos.x >= 1.8f && worldPos.x <= 4.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Stage1 = true;
                    StartSE();
                }
            }
        }

        //1.8 -12.2
        //4.3 -14.1
        //Stage2スタート
        if (worldPos.y <= -12.2f && worldPos.y >= -14.1f)
        {
            if (worldPos.x >= 1.8f && worldPos.x <= 4.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Stage2 = true;
                    StartSE();
                }
            }
        }

        //1.8 -22.0
        //4.3 -24.2
        //Stage3スタート
        if (worldPos.y <= -22.0f && worldPos.y >= -24.2f)
        {
            if (worldPos.x >= 1.8f && worldPos.x <= 4.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Stage3 = true;
                    StartSE();
                }
            }
        }

        //1.8 -31.8
        //4.3 -33.9
        //Bossスタート
        if (worldPos.y <= -31.8f && worldPos.y >= -33.9f)
        {
            if (worldPos.x >= 1.8f && worldPos.x <= 4.3f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Boss = true;
                    StartSE();
                }
            }
        }



        if (Stage1)
        {
            FadeManager.FadeOut(2);
        }

        if (Stage2)
        {
            FadeManager.FadeOut(3);
        }

        if (Stage3)
        {
            FadeManager.FadeOut(4);
        }
        if (Boss)
        {
            FadeManager.FadeOut(5);
        }
    }

    void SelectSE()
    {
        // SE再生
        _AudioSource.PlayOneShot(_AudioClip[0]);
    }

    void StartSE()
    {
        _AudioSource.PlayOneShot(_AudioClip[1]);
    }
}
