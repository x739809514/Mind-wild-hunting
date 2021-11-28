using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dinner : Drag
{
    private Vector3 BeginPos;
    public GameObject Nan;
    public GameObject Nv;
    public GameObject together;
    public GameObject Sorry;
    public UI_FadeInFadeOut fadeIn;


    private void OnTriggerEnter(Collider other)
    {
        Nan.GetComponent<Image>().DOFade(0, 1);
        Nv.GetComponent<Image>().DOFade(0, 1);
        together.GetComponent<Image>().DOFade(1, 2);
        Invoke("PiaoFu",2);

    }

    public void PiaoFu()
    {
        Sorry.SetActive(true);
        fadeIn.UI_FadeIn_Event();
        fadeIn.transform.DOMoveY(260, 4);
        Invoke("DanChu",3);
    }

    public void DanChu()
    {
        fadeIn.Ui_FadeOut_Event();
    }

}
