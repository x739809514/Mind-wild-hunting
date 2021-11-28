using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragA : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// 拖动时显示的临时图片
    /// </summary>
    private GameObject temimage;
    public Sprite talkItem;
    /// <summary>
    /// 拖动时显示临时图片的位置信息
    /// </summary>
    private RectTransform rtsform;
    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;
        temimage = new GameObject("TemImage");
        temimage.transform.SetParent(canvas.transform);
        //将正在拖动的这个临时图片设置到整个显示容器的最上层，以免被遮挡。
        temimage.transform.SetAsLastSibling();
        Image img = temimage.AddComponent<Image>();
        //添加该控件的目的是为了在目标图上空时，正在拖动的图片不会遮挡鼠标的释放事件产生。
        CanvasGroup canvasGroup = temimage.AddComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false; //设置为false的话，则该控件不响应鼠标的任何事件。
        img.sprite = talkItem;
        temimage.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 15);
        rtsform = transform as RectTransform;
        Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        Debug.Log("OnDrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject.Destroy(temimage);
        Debug.Log("OnEndDrag");
    }
    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();
        if (comp != null)
            return comp;
        var t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
    private void SetDraggedPosition(PointerEventData eventData)
    {
        RectTransform rt = temimage.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rtsform, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = rtsform.rotation;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }
}