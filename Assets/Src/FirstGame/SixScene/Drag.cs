using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.enterEventCamera, out pos);
        rt.position = pos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
