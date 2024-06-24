using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI error_text;
    public TextMeshProUGUI hardnest_text;
    public GameObject game_over;
    int lives = 0;
    int error_num = 0;

    void Start()
    {
        lives = 3;
        error_num = 0;
        Set_Game_Over_Menu(false);

        string hardnest = Game_Settings.Instance.Get_Game_Mode();

        LocalizeHardnest(hardnest);
        
    }

    private void LocalizeHardnest(string hardnest)
    {
        if (hardnest == "Easy")
        {
            if (YandexGame.savesData.language == "ru")
            {
                hardnest_text.text = "Легкий";
            }
            else if (YandexGame.savesData.language == "en")
            {
                hardnest_text.text = hardnest;
            }
            else
            {
                hardnest_text.text = "Hafif";
            }
        }
        else if (hardnest == "Medium")
        {
            if (YandexGame.savesData.language == "ru")
            {
                hardnest_text.text = "Средний";
            }
            else if (YandexGame.savesData.language == "en")
            {
                hardnest_text.text = hardnest;
            }
            else
            {
                hardnest_text.text = "Orta";
            }
        }
        else if (hardnest == "Hard")
        {
            if (YandexGame.savesData.language == "ru")
            {
                hardnest_text.text = "Сложний";
            }
            else if (YandexGame.savesData.language == "en")
            {
                hardnest_text.text = hardnest;
            }
            else
            {
                hardnest_text.text = "Sert";
            }
        }
        else if (hardnest == "Expert")
        {
            if (YandexGame.savesData.language == "ru")
            {
                hardnest_text.text = "Эксперт";
            }
            else if (YandexGame.savesData.language == "en")
            {
                hardnest_text.text = hardnest;
            }
            else
            {
                hardnest_text.text = "Uzman";
            }
        }
    }

    private void WrongNumber()
    {
        if (error_num < 3) 
        {
            error_num++;
            lives--;

            if(YandexGame.savesData.language == "ru")
            {
                error_text.text = $"Ошибки {error_num}/{3}";
            }
            else if(YandexGame.savesData.language == "en")
            {
                error_text.text = $"Wasterers {error_num}/{3}";
            }
            else
            {
                error_text.text = $"Hatalar {error_num}/{3}";
            }
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
