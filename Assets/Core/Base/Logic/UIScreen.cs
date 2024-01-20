using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract class that provide basic logic for all of bonus screens
/// </summary>
public abstract class UIScreen : MonoBehaviour
{
    private Image[] allGraphicObjects;
    private TextMeshProUGUI[] additionalGraphicToFade;

    private Color32 baseColor = new Color32(255, 255, 255, 0);

    [SerializeField] private AnimationType animationType = AnimationType.Fade;
    [SerializeField] private float fadeDuration = 0.3f;

    public bool needToAnimate = true;
    public bool overrideBaseColor = false;

    private void OnEnable()
    {
        if (animationType != AnimationType.None)
        {
            allGraphicObjects = GetComponentsInChildren<Image>(true);
            additionalGraphicToFade = GetComponentsInChildren<TextMeshProUGUI>(true);
        }

        OpenScreen();
    }

    public abstract void StartScreen();

    public virtual void CloseScreen()
    {
        gameObject.SetActive(false);
    }

    public async UniTask CloseScreenWithAnimation()
    {
        foreach (var item in allGraphicObjects)
        {
            item.DOFade(0, fadeDuration);
        }

        foreach (var item in additionalGraphicToFade)
        {
            item.DOFade(0, fadeDuration);
        }

        await UniTask.Delay((int)(fadeDuration * 1000));

        gameObject.SetActive(false);
    }

    public async UniTask CloseScreenWithAnimation(int timeOutToStart)
    {
        await UniTask.Delay(timeOutToStart);

        foreach (var item in allGraphicObjects)
        {
            item.DOFade(0, fadeDuration);
        }

        foreach (var item in additionalGraphicToFade)
        {
            item.DOFade(0, fadeDuration);
        }

        await UniTask.Delay((int)(fadeDuration * 1000));

        gameObject.SetActive(false);
    }


    private void OpenScreen()
    {
        if (!needToAnimate)
            return;

        switch (animationType)
        {
            case AnimationType.Fade:
                FadeInAnimation();
                break;
            case AnimationType.None:
                break;
        }
    }

    private void FadeInAnimation()
    {
        if (!overrideBaseColor)
        {
            foreach (var item in allGraphicObjects)
            {
                item.color = baseColor;
                item.DOFade(1, fadeDuration);
            }

            foreach (var item in additionalGraphicToFade)
            {
                item.DOFade(1, fadeDuration);
            }
        }
        else
        {
            foreach (var item in allGraphicObjects)
            {
                float itemAlpha = item.color.a;

                item.color = new Color(item.color.r, item.color.g, item.color.b, 0);
                item.DOFade(itemAlpha, fadeDuration);
            }

            foreach (var item in additionalGraphicToFade)
            {
                item.DOFade(1, fadeDuration);
            }
        }
    }
}

public enum AnimationType
{
    Fade,
    None
}