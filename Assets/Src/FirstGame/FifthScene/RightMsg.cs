using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RightMsg : MonoBehaviour
{
    public GameObject WeChatPanel;
    public GameObject LeftManBubble;
    public GameObject RightWomenBubble;
    public Transform parent;
    public GameObject Options;
    [Header("选项卡")]
    public Button BtnOption;
    public Button BtnOk;
    public Button BtnRefuse;
    public Button BtnScuess;
    public Button BtnFail;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddEventListener((uint)EventDef.WeChatMsgChange, ShowWeChatMsg);
        BtnOk.onClick.AddListener(SendMessage);
        BtnRefuse.onClick.AddListener(SendMessage2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetEvent(Notification e)
    {
        yield return new WaitForSeconds(1);
        WeChatPanel.transform.DOMoveY(248, 1);
        yield return new WaitForSeconds(1);
        AddBubble(parent, LeftManBubble, e.message);
        Options.SetActive(true);
        BtnOption.gameObject.SetActive(false);
        BtnOk.gameObject.SetActive(true);
        BtnRefuse.gameObject.SetActive(true);
        BtnScuess.gameObject.SetActive(false);
        BtnFail.gameObject.SetActive(false);
    }

    public void ShowWeChatMsg(Notification e)
    {
        StartCoroutine(GetEvent(e));
    }

    public void AddBubble(Transform parent ,GameObject obj, string text)
    {
        Instantiate(obj,parent);
        obj.GetComponentInChildren<Text>().text = text;
        foreach(Transform item in obj.transform)
        {
            if (item.name == "Image")
            {
                item.GetComponentInChildren<Text>().text = text;
            }
        }
    }

    public void SendMessage()
    {
        //EventArgsTest args = new EventArgsTest(BtnOk.gameObject, "好的");
        Notification msg = new Notification(BtnOk.gameObject,"好的");
        EventManager.Instance.Dispatch((uint)EventDef.WeChatBackMsgChange, msg);
        AddBubble(parent, RightWomenBubble, "好的");
        Options.SetActive(false);
    }

    public void SendMessage2()
    {
        Notification msg = new Notification(BtnRefuse.gameObject, "不用了，我自己带了伞");
        EventManager.Instance.Dispatch((uint)EventDef.WeChatBackMsgChange, msg);
        AddBubble(parent, RightWomenBubble, "不用了，我自己带了伞");
        Options.SetActive(false);
    }
}
