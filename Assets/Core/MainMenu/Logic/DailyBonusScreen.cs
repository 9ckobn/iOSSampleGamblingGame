using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusScreen : UIScreen
{
    [SerializeField] private TextMeshProUGUI headerText;

    private const string h1_1 = "Daily Bonus";
    private const string h1_1_1 = "Daily Bonus";
    private const string h1_2 = "Rolling dice";
    private const string h1_3 = "You won!";

    [SerializeField] private ClickableElement rollButton, continueButton;

    [SerializeField] private GameObject main, timer, win;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private Sprite[] diceAtlas;
    [SerializeField] private Image dice;

    [SerializeField] private TextMeshProUGUI multiText, earnText, coinsText;

    private int currentWin = 10; //maybe to wins array like [10, 100, 500...]

    public bool isWin = false;

    public Action onClose;

    public override void StartScreen()
    {
        if (isWin)
        {
            headerText.text = h1_1_1;
        }
        else
        {
            headerText.text = h1_1;
        }

        rollButton.OnClick += StartRoll;

        gameObject.SetActive(true);
    }

    private void StartRoll()
    {
        main.SetActive(false);
        headerText.text = h1_2;
        timer.SetActive(true);

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        YieldInstruction waitSec = new WaitForSeconds(1);

        for (int i = 3; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return waitSec;
        }

        GenerateWin();
    }

    private void GenerateWin()
    {
        currentWin = 10;

        timer.SetActive(false);

        headerText.text = h1_3;

        var randomX = UnityEngine.Random.Range(1, 6);

        dice.sprite = diceAtlas[randomX - 1];

        var totalWin = currentWin * randomX;

        multiText.text = $"x{randomX}";
        earnText.text = $"You just earned <color=#F12C4C>{currentWin}<sprite=0>x{randomX}!";
        coinsText.text = $"<color=#F12C4C>{totalWin}<sprite=0>";

        currentWin = totalWin;

        continueButton.OnClick = async () => await GetWin();

        win.SetActive(true);
    }

    private async UniTask GetWin()
    {
        PlayerStats.MoneyCount += currentWin;
        await CloseScreenWithAnimation();
        onClose?.Invoke();

        MenuHandler.instance.LoadMainMenu();
    }
}
