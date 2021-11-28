using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragB : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject myBubble;
    private GameObject bubble;
    private GameObject temimage;
    private RectTransform rtsform;
    public static int count;

    public void OnDrop(PointerEventData eventData)
    {
        var co = GameObject.Find("CameraOne");
        Debug.Log("拖动的图:" + eventData.pointerDrag.name + " 目标图:" + gameObject.name);
        gameObject.GetComponent<Image>().DOFade(1, 0);//eventData.pointerDrag.GetComponent<Image>().sprite;

        bubble = GameObject.Instantiate(myBubble, co.transform) as GameObject;
        bubble.transform.localScale = new Vector3(1, 1, 1);
        bubble.transform.DOMoveY(280, 1);
        bubble.transform.DOScale(new Vector3(2f, 2f, 1), 1);
        bubble.GetComponent<Image>().DOFade(0, 10);
        Invoke("DestoryBubble",10);
        DragB.count++;
    }

    public void DestoryBubble()
    {
        Destroy(bubble);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //var abc = eventData.pointerDrag;
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
