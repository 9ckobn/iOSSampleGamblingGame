using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;
    public Sprite defaultSprite, runningSprite;

    public Image playerImage;
    public Sprite defaultPlayerSprite, runningPlayerSprite;

    public bool isRunning = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = runningSprite;

        playerImage.sprite = runningPlayerSprite;
        playerImage.SetNativeSize();

        isRunning = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = defaultSprite;

        playerImage.sprite = defaultPlayerSprite;
        playerImage.SetNativeSize();

        isRunning = false;
    }
}
