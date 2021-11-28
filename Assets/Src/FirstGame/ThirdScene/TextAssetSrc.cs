using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAssetSrc : MonoBehaviour
{
    public Text textLable;
    public TextAsset textFile;

    public int index;
    public float speed;
    private bool textFinish;
    private GameObject mail;
    List<string> textList = new List<string>();

    public GameObject phone;
    public Button NextBtn;

    public UI_FadeInFadeOut fadeInFadeOut;

    private void Awake()
    {
        GetTextForFile(textFile);
        index = 0;
        mail = GameObject.Find("MailPanel");
        
    }

    private void Start()
    {
        Camera.main.orthographic = false;
        NextBtn.onClick.AddListener(GoToNextText);
    }

    private void OnEnable()
    {
        textFinish = true;
        StartCoroutine(SetTextUI());
    }

    private void Update()
    {
        if (index == textList.Count)
        {
            fadeInFadeOut.Ui_FadeOut_Event();
            StartCoroutine(CallGirlFriend());
        }

    }

    public void GoToNextText()
    {
        if (textFinish)
        {
            StartCoroutine(SetTextUI());
        }
    }

    public void GetTextForFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        //切割
        var LineData = file.text.Split('\n');
        foreach (var line in LineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinish = false;
        textLable.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLable.text += textList[index][i];
            yield return new WaitForSeconds(speed);
        }

        textFinish = true;
        index++;
    }

    IEnumerator CallGirlFriend()
    {
        yield return new WaitForSeconds(1);
        phone.transform.DOMoveY(200, 1);
    }

}