using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ItemScaleChange : MonoBehaviour
{
    public GameObject item;
    public Vector3 scale;
    public GameObject obj;
    public UI_FadeInFadeOut fadein;

    public void OnMouseEnter(BaseEventData eventData)
    {
        //PointerEventData pointerEventData = eventData as PointerEventData;
        //string str = pointerEventData.pointerEnter.ToString();
        item.transform.DOScale(scale,0.5f);
    }

    public void OnMouseExit(BaseEventData eventData)
    {
        item.transform.DOScale(new Vector3(1f, 1f, 1), 0.5f);
    }

    public void OnMouseClick(BaseEventData eventData)
    {
        obj.SetActive(true);
        fadein.UI_FadeIn_Event();
    }
    // Start is called before the first frame update
    void Awake()
    {
        //fadein = GameObject.Find("mailInfo").GetComponent<UI_FadeInFadeOut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
