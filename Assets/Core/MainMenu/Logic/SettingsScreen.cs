using System;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;


public class SettingsScreen : UIScreen
{
    [SerializeField] private Sprite notifToggleEnable, notifToggleDisable;
    [SerializeField] private UnityEngine.UI.Button notification, privacy, terms, share, rate, close;
    [SerializeField] private string privacyUrl, termsUrl;

    private NativeShare nativeShareInstance;
    private WebViewObject webViewObject;

    private const string notificationKey = "notifs";
    private bool notificationsEnabled
    {
        get => PlayerPrefs.GetInt(notificationKey, 1) == 1;
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt(notificationKey, 1);
                notification.targetGraphic.GetComponent<Image>().sprite = notifToggleEnable;
            }
            else
            {
                PlayerPrefs.SetInt(notificationKey, 0);
                notification.targetGraphic.GetComponent<Image>().sprite = notifToggleDisable;
            }
        }
    }

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        SetupNotification();

        SetupButtons();
    }

    private void SetupNotification()
    {
        //todo Add Notification Service here
        notification.targetGraphic.GetComponent<Image>().sprite = notificationsEnabled ? notifToggleEnable : notifToggleDisable;
    }

    private void SetupButtons()
    {
        close.onClick.AddListener(async () =>
        {
            await CloseScreenWithAnimation();
            MenuHandler.instance.LoadMainMenu();

            notification.onClick.RemoveAllListeners();
            privacy.onClick.RemoveAllListeners();
            terms.onClick.RemoveAllListeners();
            share.onClick.RemoveAllListeners();
            rate.onClick.RemoveAllListeners();
            close.onClick.RemoveAllListeners();
        });

        notification.onClick.AddListener(SwitchNotifications);
        privacy.onClick.AddListener(() => OpenWebView(privacyUrl));
        terms.onClick.AddListener(() => OpenWebView(termsUrl));
        share.onClick.AddListener(ShareApp);
        rate.onClick.AddListener(() => Device.RequestStoreReview());
    }

    private void ShareApp()
    {
        if (nativeShareInstance == null)
        {
            nativeShareInstance = new NativeShare().SetTitle("Title").SetText("SubTitle and url to game at appstore");
        }
        else
        {
            nativeShareInstance.Share();
        }
    }

    private void OpenWebView(string URL)
    {
        webViewObject = (new GameObject("WebView")).AddComponent<WebViewObject>();
        webViewObject.Init(
            err: (msg) =>
            {
                Debug.Log($"Error: {msg}");
                Disable();
            },
            httpErr: (msg) =>
            {
                Debug.Log($"HttpError: {msg}");
                Disable();
            });

        webViewObject.LoadURL(URL);
        webViewObject.SetVisibility(true);
    }

    private void Disable()
    {
        Destroy(webViewObject.gameObject);
    }

    private void SwitchNotifications() => notificationsEnabled = !notificationsEnabled;
}

