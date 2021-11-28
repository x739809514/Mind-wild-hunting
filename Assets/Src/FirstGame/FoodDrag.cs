using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector3 BeginPos;
    private RectTransform rt;
    private bool isInRightArea;
    private GameObject box;


    private void Start()
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
        BeginPos = rt.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isInRightArea)
        {
            box.GetComponentInChildren<Image>().sprite = gameObject.transform.GetComponent<Image>().sprite;
            EventManager.Instance.Dispatch((uint)EventDef.CookDragEnd);
            Destroy(gameObject);
        }
        else
        {
            transform.position = BeginPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        box = other.gameObject;
        string gameObjName = gameObject.name.ToString();
        if (other.CompareTag("FoodBox"))
        {
            print("捕捉到了");
            isInRightArea = true;
        }
        else
        {
            isInRightArea = false;
        }
    }




}
