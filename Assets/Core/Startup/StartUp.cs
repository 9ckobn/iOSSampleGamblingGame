using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    private const int MainMenuSceneIndex = 2;
    private const int OnBoardSceneIndex = 1;

    void Start()
    {
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


