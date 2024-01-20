using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnBoardScreen : UIScreen, IPointerClickHandler
{
    public Action onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

    public override void StartScreen()
    {
        gameObject.SetActive(true);
    }
}