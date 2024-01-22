using System;
using UnityEngine;

public class OpenGame : ClickableElement
{
    public Action openGame;

    void OnEnable()
    {
        OnClick = openGame;
    }

    void OnDisable()
    {
        OnClick = null;
    }
}