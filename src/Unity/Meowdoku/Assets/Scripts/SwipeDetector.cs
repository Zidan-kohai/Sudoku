using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RecordController recordController;
    [SerializeField] private Image easyMode;
    [SerializeField] private Image mediumMode;
    [SerializeField] private Image hardMode;
    [SerializeField] private TextMeshProUGUI currentHardView;
    [SerializeField] private Sprite selectSprite;
    [SerializeField] private Sprite unSelectSprite;
    [SerializeField] private Vector2 unSelectSpriteSize;
    [SerializeField] private Vector2 SelectSpriteSize;


    [SerializeField] private Vector3 downHandler;
    [SerializeField] private Vector3 upHandler;
    [SerializeField] private Vector3 deltaHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        downHandler = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upHandler = eventData.position;

        deltaHandler = upHandler - downHandler;

        if(deltaHandler.x < -100)
        {
            recordController.RightMode();
        }
        else if(deltaHandler.x > 100)
        {
            recordController.LeftMode();
        }

        OnSwitchHardnest();
    }

    private void OnSwitchHardnest()
    {
        switch(recordController.GetType)
        {
            case RecordController.Type.Easy:
                easyMode.sprite = selectSprite;
                easyMode.rectTransform.sizeDelta = SelectSpriteSize;

                mediumMode.sprite = unSelectSprite;
                mediumMode.rectTransform.sizeDelta = unSelectSpriteSize;

                hardMode.sprite = unSelectSprite;
                hardMode.rectTransform.sizeDelta = unSelectSpriteSize;

                currentHardView.text = "Easy";
                break;

            case RecordController.Type.Medium:
                easyMode.sprite = unSelectSprite;
                easyMode.rectTransform.sizeDelta = unSelectSpriteSize;

                mediumMode.sprite = selectSprite;
                mediumMode.rectTransform.sizeDelta = SelectSpriteSize;

                hardMode.sprite = unSelectSprite;
                hardMode.rectTransform.sizeDelta = unSelectSpriteSize;

                currentHardView.text = "Medium";
                break;

            case RecordController.Type.Hard:
                easyMode.sprite = unSelectSprite;
                easyMode.rectTransform.sizeDelta = unSelectSpriteSize;

                mediumMode.sprite = unSelectSprite;
                mediumMode.rectTransform.sizeDelta = unSelectSpriteSize;

                hardMode.sprite = selectSprite;
                hardMode.rectTransform.sizeDelta = SelectSpriteSize;

                currentHardView.text = "Hard";
                break;
        }
    }
}
