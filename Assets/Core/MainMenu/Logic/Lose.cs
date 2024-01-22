using System;
using UnityEngine;

public class Lose : UIScreen
{
    public ClickableElement restartButton, quitButton;

    public Action closeScreen, toMenu, restart;

    public override void StartScreen()
    {
        restartButton.OnClick = restart;
        quitButton.OnClick = toMenu;

        gameObject.SetActive(true);
        // throw new System.NotImplementedException();
    }
}