using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameController gameController;

    public Image vignette;

    public RectTransform bg;

    public float speed = 5;

    public PlayerController controller;

    void Start()
    {
        StartCoroutine(PlayerMove());
    }

    IEnumerator PlayerMove()
    {
        float timer = 0;

        while (true)
        {
            if (controller.isRunning)
            {
                bg.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0);

                timer += Time.deltaTime;

                if (timer >= Random.Range(1f, 3f))
                {
                    EndHP();
                    timer = 0;
                }

                //Debug.Log(bg.anchoredPosition.x);

                if (bg.anchoredPosition.x < -3000)
                {
                    gameController.Win();
                }
            }

            yield return null;
        }
    }

    public void EndHP()
    {
        var clearColor = new Color(1, 1, 1, 0);

        vignette.color = clearColor;
        vignette.DOFade(1f, 0.65f).OnComplete(
            () =>
            {
                vignette.color = clearColor;

                if (controller.isRunning)
                {
                    gameController.Lose();
                }
            }
        ).SetEase(Ease.Linear);
    }
}