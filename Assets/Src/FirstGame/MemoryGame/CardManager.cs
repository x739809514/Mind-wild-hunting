using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    private const int winCardCouples = 6;
    private int curCardCouples = 0; //当前已经匹配的卡牌数
    private bool canPlayerClick = true;

    public Sprite BackSprite;
    public Sprite SuccessSprite;
    public Sprite[] FrontSprites;

    public GameObject CardPre;
    public Transform CardView;
    private List<GameObject> CardObjs;
    private List<Card> FaceCards;

    public GameObject PsGame;
    public GameObject PsImage;

    private void Start()
    {
        CardObjs = new List<GameObject>();
        FaceCards = new List<Card>();
        for(int i = 0; i < 6; i++)
        {
            Sprite FrontSprite = FrontSprites[i];
            for (int j=0;j<2;j++)
            {
                GameObject go = (GameObject)Instantiate(CardPre);
                Card card = go.GetComponent<Card>();
                card.InitCard(i, FrontSprite, BackSprite, SuccessSprite);
                card.BtnCard.onClick.AddListener(() => CardOnClick(card));

                CardObjs.Add(go);
            }
        }

        while (CardObjs.Count > 0)
        {
            //去随机数，左闭右开区间
            int ran = Random.Range(0, CardObjs.Count);
            GameObject go = CardObjs[ran];
            //将对象指定给panel作为子物体
            go.transform.parent = CardView;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            CardObjs.RemoveAt(ran);
        }
        GetTimer();
    }
    

    private void CardOnClick(Card card)
    {
        if (canPlayerClick)
        {
            card.SetFanPai();
            FaceCards.Add(card);
            if (FaceCards.Count == 2)
            {
                //进入判断
                canPlayerClick = false;
                //进入协程
                StartCoroutine(JugdeTwoCards());
            }
        }
    }
    IEnumerator JugdeTwoCards()
    {
        //获取到两张卡牌对象
        Card card1 = FaceCards[0];
        Card card2 = FaceCards[1];
        //对ID进行比对
        if (card1.ID == card2.ID)
        {
            Debug.Log("Success......");
            //此时会在此处等待0.8秒后再执行下一条语句
            //协程不影响主程序的进行，这里可以做个小实验
            //将下面的0.8改成8秒，在Update中打印Time.time会发现不会有停顿的时候
            yield return new WaitForSeconds(0.5f);
            card1.SetSuccess();
            card2.SetSuccess();
            curCardCouples++;
            if (curCardCouples == winCardCouples)
            {
                //弹出成功的图
                PsGame.SetActive(false);
                PsImage.SetActive(true);
                PsImage.GetComponent<Image>().DOFade(0, 4);
            }
        }
        else
        {
            Debug.Log("Failure......");
            //配对失败等待的时间要更长，因为要让玩家记忆更深刻
            yield return new WaitForSeconds(1f);
            card1.SetRecover();
            card2.SetRecover();
        }

        FaceCards = new List<Card>();
        canPlayerClick = true;
    }

    public void GetTimer()
    {
        StartCoroutine(DoTimer(30));
    }

    IEnumerator DoTimer(int time)
    {
        while (time>0)
        {
            time--;
            GetComponentInChildren<Text>().text = time.ToString();
            yield return new  WaitForSeconds(1);
        }
        //弹出失败的图
        
    }
    
    
}

