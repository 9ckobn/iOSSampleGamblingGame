using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScreen : UIScreen
{
    [SerializeField] DefaultButton back;

    public override void StartScreen()
    {
        gameObject.SetActive(true);
        back.OnClick = () => back.OpenScreenAsync(this);
    }
}
