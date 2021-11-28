using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChatMsg : MonoBehaviour
{
    public Transform NeedGameObject;
    private bool IsMove = false;
    public Button Phone;
    [Header("左右气泡")]
    public GameObject LeftManBubble;
    public GameObject LeftWomenBubble;
    public GameObject RightManBubble;
    public GameObject RightWomanBubble;

    [Header("聊天面板")]
    public GameObject LeftWeChat;
    public GameObject RightWeChat;
    public GameObject Options;
    [Header("聊天气泡父级容器")]
    public Transform parent;
    [Header("选项卡")]
    public Button BtnOption;
    public Button BtnOk;
    public Button BtnRefuse;
    public Button BtnScuess;
    public Button BtnFail;

    public GameObject NextScene;
    public UI_FadeInFadeOut FadeOut;
    private void Start()
    {
        StartCoroutine(DoShake());
        Phone.onClick.AddListener(ShowChatPanel);
        BtnOption.onClick.AddListener(SendMessage);
        EventManager.Instance.AddEventListener((uint)EventDef.WeChatBackMsgChange, GetMessage);
        BtnScuess.onClick.AddListener(GotoNextScene);
    }

    private void Update()
    {
        if (GetComponent<CanvasGroup>().alpha==0)
        {
            NextScene.SetActive(true);
        }
    }


    IEnumerator DoShake()
    {
        yield return new WaitForSeconds(2);
        MyShake(NeedGameObject);
    }

    private void ShowChatPanel()
    {
        LeftWeChat.transform.DOMoveY(248, 1);
        Options.SetActive(true);
        BtnOption.gameObject.SetActive(true);
        BtnOk.gameObject.SetActive(false);
        BtnRefuse.gameObject.SetActive(false);
    }

    public void MyShake(Transform tf)
    {
        if (tf != null)
        {
            Tweener tweener = tf.DOShakePosition(2, new Vector3(2, 2, 0), 20);
        }
    }

    public void AddBubble(Transform parent, GameObject obj, string text)
    {
        Instantiate(obj, parent);
        obj.GetComponentInChildren<Text>().text = text;
        foreach (Transform item in obj.transform)
        {
            if (item.name == "Image")
            {
                item.GetComponentInChildren<Text>().text = text;
            }
        }
    }

    public void SendMessage()
    {
        Notification msg = new Notification("下雨了，晚上送你回家吧");
        EventManager.Instance.Dispatch((uint)EventDef.WeChatMsgChange, msg);
        AddBubble(parent, RightManBubble, "下雨了，晚上送你回家吧");
        Options.SetActive(false);
    }

    public void GetMessage(Notification e)
    {
        StartCoroutine(GetEvent(e));
    }

    IEnumerator GetEvent(Notification e)
    {
        yield return new WaitForSeconds(1);
        if (e.sender.name == "BtnOk" || e.sender.name == "BtnRefuse")
        {
            AddBubble(parent, LeftWomenBubble, e.message);
            Options.SetActive(true);
            BtnOption.gameObject.SetActive(false);
            BtnOk.gameObject.SetActive(false);
            BtnRefuse.gameObject.SetActive(false);
            if(e.sender.name == "BtnOk")
            {
                BtnScuess.gameObject.SetActive(true);
                BtnFail.gameObject.SetActive(false);
            }
            else if (e.sender.name == "BtnRefuse")
            {
                BtnScuess.gameObject.SetActive(false);
                BtnFail.gameObject.SetActive(true);
            }
        }

    }

    public void GotoNextScene()
    {
        FadeOut.Ui_FadeOut_Event();
    }
}
