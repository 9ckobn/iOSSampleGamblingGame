using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : ClickableElement
{
    public Image mainImage;


    [HideInInspector]
    public Image backGroundImage;


    [HideInInspector]
    public int myIndex;

    void Start()
    {
        backGroundImage = targetGraphic;
    }

    public void SetupOnClick(ShopScreen screen, int myIndex)
    {
        this.myIndex = myIndex;

        OnClick += () =>
        {
            Debug.Log("Click");
            screen.OpenCard(this);
            backGroundImage.sprite = screen.selectedSprite;
        };
    }
}
