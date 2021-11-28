using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FadeInFadeOut : MonoBehaviour
{
    private float UI_Alpha = 1;      //UI透明度
    public float alphaSpeed = 2f;   //渐隐渐显速度
    public CanvasGroup canvasGroup;

    private void Start()
    {
        //canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (canvasGroup == null)
        {
            return;
        }
        if (UI_Alpha != canvasGroup.alpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
            }
        }
    }

    public void UI_FadeIn_Event()
    {
        UI_Alpha = 1;
        canvasGroup.blocksRaycasts = true;      //可以和对象交互
    }

    public void Ui_FadeOut_Event()
    {
        UI_Alpha = 0;
        canvasGroup.blocksRaycasts = false;     //不可以和对象交互
    }
}
