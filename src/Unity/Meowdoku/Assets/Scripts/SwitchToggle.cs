using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private RectTransform handleRect;
    [SerializeField] private Image background;
    [SerializeField] private Image handle;

    [SerializeField] private Vector2 handleOfPosition;


    [Space]
    [SerializeField] private Sprite onBackground;
    [SerializeField] private Sprite ofBackground;
    [SerializeField] private Sprite onHandle;
    [SerializeField] private Sprite ofHandle;

    void Start()
    {
        handleOfPosition = handleRect.anchoredPosition;

        toggle.onValueChanged.AddListener(OnSwitch);

        OnSwitch(DataController.Instanse.PlayerData.IsVibrationOn);
    }

    private void OnSwitch(bool on)
    {
        DataController.Instanse.PlayerData.IsVibrationOn = on;
        DataController.Instanse.Save();

        if (on)
        {
            handle.sprite = onHandle;
            background.sprite = onBackground;
            handleRect.anchoredPosition = handleOfPosition * -1;
        }
        else
        {
            handle.sprite = ofHandle;
            background.sprite = ofBackground;
            handleRect.anchoredPosition = handleOfPosition;
        }
    }
}
