using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject WinScreen;
    void Start()
    {
        WinScreen.SetActive(false);
        Set_Win_Menu(false);
    }

    private void On_Board_Full()
    {
        WinScreen.SetActive(true); // Win screen popup appears
        Set_Win_Menu(true);

        //if we win less than 5 min we enable achiement
        if (Timer.instance.Get_Seconds() < 300)
        {
            if(Game_Settings.Instance.Get_Game_Mode() == "Easy")
            {
                DataController.Instanse.PlayerData.Achievement1 = true;

            }
            else if(Game_Settings.Instance.Get_Game_Mode() == "Medium")
            {
                DataController.Instanse.PlayerData.Achievement2 = true;
            }
            else if (Game_Settings.Instance.Get_Game_Mode() == "Hard")
            {
                DataController.Instanse.PlayerData.Achievement3 = true;
            }

            DataController.Instanse.Save();
        }
    }

    public void Set_Win_Menu(bool win) // Stops win time
    {
        Game_Settings.Instance.Set_Win(win);
    }

    private void OnEnable()
    {
        Game_Events.On_Board_Full += On_Board_Full;
    }
    private void OnDisable()
    {
        Game_Events.On_Board_Full -= On_Board_Full;
    }
}
