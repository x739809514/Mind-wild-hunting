using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 itemTouchPos;
    private Vector3 itemVec;
    private Ray ray;
    private RaycastHit hit;
    public GameObject item;
    public LayerMask layerMask;

    public void PointDown()
    {
        itemTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPos = pointerEventData.position;
        itemVec = (DragPos - itemTouchPos).normalized;
        float distance = Vector3.Distance(DragPos, itemTouchPos);
        item.transform.position = itemTouchPos + itemVec * distance;
    }

    public void PointUp(BaseEventData eventData)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, 100, layerMask))
        {
            if (hit.collider.tag == "Block")
            {
                Debug.Log("碰到");
            }
        }
        PointerEventData pointerEventData = eventData as PointerEventData;
        Debug.Log(pointerEventData);
    }
}
