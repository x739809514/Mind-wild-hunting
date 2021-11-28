using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private int id;
    public int ID
    {
        get
        {
            return id;
        }
    }
    private Sprite FrontCard;
    private Sprite BackCard;
    private Sprite ScuessCard;

    private Image ShowImage;
    public Button BtnCard;

    public void InitCard(int id,Sprite frontCard,Sprite backCard,Sprite successCard)
    {
        this.id = id;
        this.FrontCard = frontCard;
        this.BackCard = backCard;
        this.ScuessCard = successCard;

        ShowImage = GetComponent<Image>();
        ShowImage.sprite = this.BackCard;
        this.BtnCard = GetComponent<Button>();
    }

    public void SetFanPai()
    {
        this.ShowImage.sprite = FrontCard;
        this.BtnCard.interactable = false;
    }

    public void SetSuccess()
    {
        this.ShowImage.sprite = ScuessCard;
    }

    public void SetRecover()
    {
        this.ShowImage.sprite = BackCard;
        this.BtnCard.interactable = true;
    }

}
