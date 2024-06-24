using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

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

                LocalizeHardnest("Easy");
                break;

            case RecordController.Type.Medium:
                easyMode.sprite = unSelectSprite;
                easyMode.rectTransform.sizeDelta = unSelectSpriteSize;

                mediumMode.sprite = selectSprite;
                mediumMode.rectTransform.sizeDelta = SelectSpriteSize;

                hardMode.sprite = unSelectSprite;
                hardMode.rectTransform.sizeDelta = unSelectSpriteSize;

                LocalizeHardnest("Medium");
                break;

            case RecordController.Type.Hard:
                easyMode.sprite = unSelectSprite;
                easyMode.rectTransform.sizeDelta = unSelectSpriteSize;

                mediumMode.sprite = unSelectSprite;
                mediumMode.rectTransform.sizeDelta = unSelectSpriteSize;

                hardMode.sprite = selectSprite;
                hardMode.rectTransform.sizeDelta = SelectSpriteSize;

                LocalizeHardnest("Hard");
                break;
        }
    }


    private void LocalizeHardnest(string hardnest)
    {
        if (hardnest == "Easy")
        {
            if (YandexGame.savesData.language == "ru")
            {
                currentHardView.text = "Легкий";
            }
            else if (YandexGame.savesData.language == "en")
            {
                currentHardView.text = hardnest;
            }
            else
            {
                currentHardView.text = "Hafif";
            }
        }
        else if (hardnest == "Medium")
        {
            if (YandexGame.savesData.language == "ru")
            {
                currentHardView.text = "Средний";
            }
            else if (YandexGame.savesData.language == "en")
            {
                currentHardView.text = hardnest;
            }
            else
            {
                currentHardView.text = "Orta";
            }
        }
        else if (hardnest == "Hard")
        {
            if (YandexGame.savesData.language == "ru")
            {
                currentHardView.text = "Сложний";
            }
            else if (YandexGame.savesData.language == "en")
            {
                currentHardView.text = hardnest;
            }
            else
            {
                currentHardView.text = "Sert";
            }
        }
        else if (hardnest == "Expert")
        {
            if (YandexGame.savesData.language == "ru")
            {
                currentHardView.text = "Эксперт";
            }
            else if (YandexGame.savesData.language == "en")
            {
                currentHardView.text = hardnest;
            }
            else
            {
                currentHardView.text = "Uzman";
            }
        }
    }
}
