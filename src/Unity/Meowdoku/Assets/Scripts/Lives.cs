using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI error_text;
    public GameObject game_over;
    int lives = 0;
    int error_num = 0;

    void Start()
    {
        lives = 3;
        error_num = 0;
        Set_Game_Over_Menu(false);
    }

    private void WrongNumber()
    {
        if (error_num < 3) 
        {
            error_num++;
            lives--;
            error_text.text = $"Wasterers {error_num}/{3}";
        }

        Check_Game_Over();
    }

    private void Check_Game_Over()
    {
        if (lives <= 0)
        {
            Game_Events.On_Game_Over_Func();
            game_over.SetActive(true);
            Set_Game_Over_Menu(true);
        }
    }

    public void Set_Game_Over_Menu(bool game_over_bool)
    {
        Game_Settings.Instance.Set_Game_Over(game_over_bool);
    }

    private void OnEnable()
    {
        Game_Events.On_Wrong_Number += WrongNumber;
    }

    private void OnDisable()
    {
       Game_Events.On_Wrong_Number -= WrongNumber;    
    }
}
