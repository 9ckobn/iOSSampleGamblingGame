using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image blur;

    [SerializeField] DailyBonusScreen winScreen;

    [SerializeField] ClickableElement pauseButton;

    [SerializeField] Pause pauseScreen;
    [SerializeField] Lose loseScreen;

    public GameController thisObject;

    void Start()
    {
        pauseButton.OnClick = OpenPause;
    }

    public void Win()
    {
        blur.enabled = true;
        winScreen.onClose = () => Destroy(gameObject);
        winScreen.isWin = true;
        winScreen.StartScreen();
    }

    void OpenPause()
    {
        blur.enabled = true;
        pauseScreen.closeScreen = () =>
        {
            pauseScreen.CloseScreenWithAnimation();
            blur.enabled = false;
        };

        pauseScreen.toMenu = () =>
        {
            Destroy(gameObject);
            MenuHandler.instance.LoadMainMenu();
        };

        pauseScreen.restart = () =>
        {
            blur.enabled = false;
            pauseScreen.CloseScreen();
            var obj = Instantiate(thisObject);

            obj.thisObject = thisObject;
            Destroy(gameObject);
        };

        pauseScreen.StartScreen();
    }

    public void Lose()
    {
        blur.enabled = true;
        loseScreen.closeScreen = () =>
        {
            loseScreen.CloseScreenWithAnimation();
            blur.enabled = false;
        };

        loseScreen.toMenu = () =>
        {
            Destroy(gameObject);
            MenuHandler.instance.LoadMainMenu();
        };

        loseScreen.restart = () =>
        {
            blur.enabled = false;
            loseScreen.CloseScreen();
            var obj = Instantiate(thisObject);

            obj.thisObject = thisObject;

            Destroy(gameObject);
        };

        loseScreen.StartScreen();
    }
}