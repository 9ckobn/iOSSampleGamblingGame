using System;
using UnityEngine;

public class Pause : UIScreen
{
    public ClickableElement continueButton, restartButton, quitButton;

    public Action closeScreen, toMenu, restart;

    public override void StartScreen()
    {
        continueButton.OnClick = closeScreen;
        restartButton.OnClick = restart;
        quitButton.OnClick = toMenu;

        gameObject.SetActive(true);
        // throw new System.NotImplementedException();
    }
}