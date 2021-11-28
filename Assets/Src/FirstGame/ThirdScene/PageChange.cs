using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageChange : MonoBehaviour
{
    public Button BtnCall;
    public GameObject scroll;
    public GameObject GFHome;
    public GameObject phone;
    public UI_FadeInFadeOut fadeOut;
    public GameObject nextScene;
    private int index; 
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        BtnCall.onClick.AddListener(ToNextPage);
        EventManager.Instance.AddEventListener((uint)EventDef.PhoneCallChange, GFRefuseCall);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CanvasGroup>().alpha==0)
        {
            nextScene.SetActive(true);
        }
    }

    public void ToNextPage()
    {
        index++;
        GFHome.SetActive(true);
        scroll.GetComponent<UIScrollerRect>().HorizontalNavigate(index);
    }

    public void GFRefuseCall(Notification e)
    {

        StartCoroutine(CallRefuse());
    }

    IEnumerator CallRefuse()
    {
        yield return new WaitForSeconds(2);
        fadeOut.Ui_FadeOut_Event();
    }
    

    public void OnDestory()
    {
        EventManager.Instance.RemoveEventListener((uint)EventDef.PhoneCallChange, GFRefuseCall);
    }
}
