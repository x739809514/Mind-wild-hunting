using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookGame : MonoBehaviour
{
    public Image CookSlider;
    public Button BtnCook;
    public GameObject result1;
    public GameObject result2;
    private float num;
    private int count;
    private GameObject box1;
    private GameObject box2;
    private GameObject box3;
    private int resultCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        BtnCook.onClick.AddListener(DoCook);
        box1 = GameObject.Find("block1").gameObject;
        box2 = GameObject.Find("block2").gameObject;
        box3 = GameObject.Find("block3").gameObject;
        EventManager.Instance.AddEventListener((uint)EventDef.CookDragEnd, AddFood);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoCook()
    {
        if (count == 3)
        {
            StartCoroutine(Cook());
        }
    }

    IEnumerator Cook()
    {
        while (num != 100)
        {
            num++;
            yield return new WaitForSeconds(0.005f);
            CookSlider.fillAmount = num / 100;
        }
        ResetCook();
        resultCount++;
        if (resultCount == 1)
        {
            result1.SetActive(true);
        }
        else if (resultCount == 2)
        {
            result2.SetActive(true);
        }
    }

    private void AddFood(Notification e)
    {
        count++;
        if (count > 3)
        {
            count = 3;
        }
    }


    private void ResetCook()
    {
        count = 0;
        num = 0;
        box1.GetComponentInChildren<Image>().sprite = null;
        box2.GetComponentInChildren<Image>().sprite = null;
        box3.GetComponentInChildren<Image>().sprite = null;
    }
}
