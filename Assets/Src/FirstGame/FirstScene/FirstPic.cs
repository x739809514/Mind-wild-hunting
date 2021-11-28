using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPic : MonoBehaviour
{
    public GameObject Bg;
    public GameObject BlockLeft;
    public GameObject BlockRight;
    public GameObject itemleft;
    public GameObject itemright;
    public GameObject item01;
    public GameObject item02;
    public GameObject button;
    public UI_FadeInFadeOut fadeInOut;
    public GameObject nextScene;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Camera.main.orthographic = false;
    }

    private void Update()
    {
        if (DragB.count == 5)
        {
            Bg.GetComponent<Image>().overrideSprite = Resources.Load("Res/battle04",typeof(Sprite)) as Sprite;
        }
        if (DragB.count == 7)
        {
            button.SetActive(true);
        }
        if (gameObject.GetComponent<CanvasGroup>().alpha == 0)
        {
            gameObject.SetActive(false);
            Invoke("GotoSecondScene", 1);
            
        }
    }

    private void OnClick()
    {
        fadeInOut.Ui_FadeOut_Event();
    }

    private void GotoSecondScene()
    {
        nextScene.SetActive(true);
    }
}
