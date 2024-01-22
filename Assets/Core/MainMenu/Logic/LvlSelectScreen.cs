using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LvlSelectScreen : UIScreen
{
    public GameConfig config;

    public List<OpenGame> openGameButtons;

    public GameObject cannot;

    public override void StartScreen()
    {
        foreach (var item in openGameButtons)
        {
            item.openGame = () => ShowCannotAsync();
        }

        foreach (var item in config.config)
        {
            openGameButtons[item.index].openGame = () =>
            {
                CloseScreen();
                var currentLev = Instantiate(item.prefab);
                currentLev.thisObject = item.prefab;
            };
        }

        gameObject.SetActive(true);
    }

    async UniTask ShowCannotAsync()
    {
        cannot.SetActive(true);
        await UniTask.Delay(3000);
        cannot.SetActive(false);
    }
}
