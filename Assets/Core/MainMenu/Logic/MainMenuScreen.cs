using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : UIScreen
{
    [Space(10)]
    [SerializeField] private DailyBonusScreen dailyBonusScreen;
    [SerializeField] private ClickableElement dailyBonusButton;

    [Space(10)]
    [SerializeField] private SettingsScreen settingsScreen;

    [Space(10)]
    [SerializeField] private ShopScreen shopScreen;
    [SerializeField] private ClickableElement shopButton;

    [Space(10)]
    [SerializeField] private TaskScreen taskScreen;
    [SerializeField] private ClickableElement taskButton;


    public override void StartScreen()
    {
        SetupButton();

        gameObject.SetActive(true);
    }

    private void SetupButton()
    {
        if (PlayerStats.FirstLoginToday)
        {
            dailyBonusButton.gameObject.SetActive(true);
            dailyBonusButton.OnClick = () => dailyBonusButton.OpenScreenAsync(this, dailyBonusScreen);
        }
        else
        {
            dailyBonusButton.gameObject.SetActive(false);
            dailyBonusButton.OnClick = null;
        }

        taskButton.OnClick = () => taskButton.OpenScreenAsync(this, taskScreen);
        shopButton.OnClick = () => taskButton.OpenScreenAsync(this, shopScreen);
    }
}
