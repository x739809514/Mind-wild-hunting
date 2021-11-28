using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorkSCene : MonoBehaviour
{
    public Toggle Task;
    public Slider WorkSlider;
    public CanvasGroup canvasGroup;
    public Text WorkCount;
    public GameObject WorkGame;
    public TextAsset textFile;
    public Text TaskText;

    [Header("显示下一个界面")] 
    public GameObject nextScene;
    public UI_FadeInFadeOut fadein;
    
    List<string> textList = new List<string>();
    private int count=0;
    private float alphaSpeed=2f;
    private float UI_Alpha = 1f;      //UI透明度

    private void Awake()
    {
        GetTextForFile(textFile);
        
    }
    void Start()
    {
        WorkSlider.onValueChanged.AddListener(OnWorkValueChange);
    }
    private void OnEnable()
    {
        TaskText.text = textList[count];
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

        if (canvasGroup.alpha == 0)
        {
            Task.isOn = false;
            UI_Alpha = 1;
            TaskText.text = textList[count];
            WorkSlider.value = 0;
        }

        WorkCount.text = count + "/" + 8;
        if (count==8)
        {
            StartCoroutine(MoveWorkGame());
        }
        
    }

    private void OnWorkValueChange(float value)
    {
        if (value == 1)
        {
            Task.isOn = true;
            UI_Alpha = 0;
            count++;
        }
    }
    
    IEnumerator MoveWorkGame()
    {
        yield return new WaitForSeconds(1.5f);
        WorkGame.transform.DOMoveY(50, 1);
        yield return new WaitForSeconds(1.5f);
        nextScene.SetActive(true);
        fadein.UI_FadeIn_Event();
    }

    public void GetTextForFile(TextAsset file)
    {
        textList.Clear();
        count = 0;

        //切割
        var LineData = file.text.Split('\n');
        foreach (var line in LineData)
        {
            textList.Add(line);
        }
    }
}
