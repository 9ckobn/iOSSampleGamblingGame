using OneSignalSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    private const int MainMenuSceneIndex = 2;
    private const int OnBoardSceneIndex = 1;

    void Start()
    {
        OneSignal.ConsentRequired = true;
        OneSignal.Initialize("885e41e4-21c9-4573-96fc-d98004376cbc");
        OneSignal.User.PushSubscription.OptIn();


        StartLoadScene();
    }

    private void StartLoadScene()
    {
        if (PlayerStats.IsFirstEnter)
        {
            var sceneTask = SceneManager.LoadSceneAsync(OnBoardSceneIndex);
        }
        else
        {
            var sceneTask = SceneManager.LoadSceneAsync(MainMenuSceneIndex);
        }
    }
}


