using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour {

    //フェード用のCanvasとImage
    private static Canvas FadeCanvas;
    private static Image FadeImage;

    //フェード用Imageの透明度
    private static float Alpha = 0.0f;

    //フェードインアウトのフラグ
    public static bool IsFadeIn = false;
    public static bool IsFadeOut = false;

    //フェードしたい時間
    private static float FadeTime = 0.2f;

    //遷移先のシーン番号
    private static int NextScene = 1;

    //フェード用のCanvasとImage生成
    static void Init()
    {
        //フェード用のCanvas
        GameObject FadeCanvasObject = new GameObject("CanvasFade");
        FadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
        FadeCanvasObject.AddComponent<GraphicRaycaster>();
        FadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        FadeCanvasObject.AddComponent<FadeManager>();

        //最前面になるようソートオーダー設定
        FadeCanvas.sortingOrder = 100;

        //フェード用のImage生成
        FadeImage = new GameObject("ImageFade").AddComponent<Image>();
        FadeImage.transform.SetParent(FadeCanvas.transform, false);
        FadeImage.rectTransform.anchoredPosition = Vector3.zero;

        //Imageのサイズ
        FadeImage.rectTransform.sizeDelta = new Vector2(1920, 1080);
    }

    //フェードイン
    public static void FadeIn()
    {
        if (FadeImage == null) Init();
        FadeImage.color = Color.black;
        IsFadeIn = true;
    }

    //フェードアウト
    public static void FadeOut(int n)
    {
        if (FadeImage == null) Init();
        NextScene = n;
        FadeImage.color = Color.clear;
        FadeCanvas.enabled = true;
        IsFadeOut = true;
    }

    void Update()
    {
        if (IsFadeIn)
        {
            //経過時間から透明度計算
            Alpha -= Time.deltaTime / FadeTime;

            //フェードイン終了
            if (Alpha <= 0.0f)
            {
                IsFadeIn = false;
                Alpha = 0.0f;
                FadeCanvas.enabled = false;
            }

            //フェード用Imageの透明度
            FadeImage.color = new Color(0.0f, 0.0f, 0.0f, Alpha);
        }
        else if (IsFadeOut)
        {
            Alpha += Time.deltaTime / FadeTime;

            if (Alpha >= 1.0f)
            {
                IsFadeOut = false;
                Alpha = 1.0f;

                //次のシーンへ
                SceneManager.LoadScene(NextScene);
            }

            FadeImage.color = new Color(0.0f, 0.0f, 0.0f, Alpha);
        }
    }
}
