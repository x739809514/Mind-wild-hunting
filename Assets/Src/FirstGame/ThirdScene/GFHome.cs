using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GFHome : MonoBehaviour
{
    public GameObject phone;
    public Button refuse;
    public Button RefuseCall;
    public Button AnswerBtn;
    private int index;
    public GameObject scroll;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetCall());
        RefuseCall.onClick.AddListener(DoCoroutine);
        AnswerBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetCall()
    {
        yield return new WaitForSeconds(5);
        phone.transform.DOMoveY(200, 1);
    }
    
    public void DoCoroutine()
    {
        StartCoroutine(BackToLastPage());
    }

    IEnumerator BackToLastPage()
    {
        phone.transform.DOMoveY(50, 1);
        yield return new WaitForSeconds(2);
        index=0;
        scroll.GetComponent<UIScrollerRect>().HorizontalNavigate(index);
        EventManager.Instance.Dispatch((uint)EventDef.PhoneCallChange);
        gameObject.SetActive(false);
    }
}
