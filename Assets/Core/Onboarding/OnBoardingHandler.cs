using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnBoardingHandler : MonoBehaviour
{
    [SerializeField] private OnBoardScreen[] screens;

    private int onboardIndex = 0;
    private const int mainMenuSceneIndex = 2;

    void Start()
    {
        foreach (var item in screens)
        {
            item.onClick += NextScreen;
        }

        screens[onboardIndex].StartScreen();
    }

    private async void NextScreen()
    {
        await screens[onboardIndex].CloseScreenWithAnimation();
        onboardIndex++;

        if (onboardIndex >= screens.Count())
        {
            PlayerStats.SetFirstEnter();
            SceneManager.LoadSceneAsync(mainMenuSceneIndex);
            return;
        }

        screens[onboardIndex].StartScreen();
    }
}
