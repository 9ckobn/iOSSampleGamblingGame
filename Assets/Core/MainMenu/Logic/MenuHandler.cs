using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private MainMenuScreen mainMenuScreen;

    public static MenuHandler instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        mainMenuScreen.StartScreen();
    }
}
