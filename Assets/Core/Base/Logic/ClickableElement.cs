using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

/// <summary>
/// Abstract class that provide basic IPointerClick interface
/// Basically need to work with clickable elements in screens
/// </summary>
public abstract class ClickableElement : MonoBehaviour, IClickableElement
{
    [SerializeField] protected Image targetGraphic;

    protected bool needToAnimate = true;

    private const float animationModifier = 1.05f;
    private const float animationDuration = 0.05f;

    public Action OnClick;

    private void Start()
    {
        if (needToAnimate) OnClick += OnClickAnimation;
    }

    public virtual async UniTask OpenScreenAsync(UIScreen current, UIScreen next)
    {
        await current.CloseScreenWithAnimation();
        next.StartScreen();
    }

    public virtual async UniTask OpenScreenAsync(UIScreen current)
    {
        await current.CloseScreenWithAnimation();
        MenuHandler.instance.LoadMainMenu();
    }

    private void OnEnable()
    {
        if (targetGraphic == null)
            targetGraphic = GetComponent<Image>();
    }

    private void OnDestroy()
    {
        OnClick = null;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void OnClickAnimation()
    {
        targetGraphic.rectTransform.DOScale(transform.localScale * animationModifier, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}