using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MemoryCatch : MonoBehaviour
{
    public GameObject sofa;
    public GameObject ps;
    public GameObject easel;
    public GameObject sofaGame;
    public GameObject psGame;
    public GameObject Bear;
    public Button nextBtn;
    public GameObject nextPage;

    private void Start()
    {
        nextBtn.onClick.AddListener(GoNextScene);
    }

    public void OnMouseEnter(BaseEventData eventData)
    {
        PointerEventData pointerEventData=eventData as PointerEventData;
        pointerEventData.pointerCurrentRaycast.gameObject.transform.DOScale(new Vector3(1.1f, 1.1f, 1), 0.5f);       
    }

    public void OnMouseExit(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        pointerEventData.pointerCurrentRaycast.gameObject.transform.DOScale(new Vector3(1f, 1f, 1), 0.5f);
    }

    public void UIOnClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        String str = pointerEventData.pointerEnter.ToString();
        if (str.Contains("SoFa"))
        {
            sofaGame.SetActive(true);
        }
        
        else if (str.Contains("PS"))
        {
            psGame.SetActive(true);
        }
        else
        {
            
        }
    }

    public void GoNextScene()
    {
        nextPage.SetActive(true);
        gameObject.SetActive(false);
    }
}
