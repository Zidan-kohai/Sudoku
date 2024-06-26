using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Xml.Schema;
using System;
using DG.Tweening;

public class Grid_Square : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject number_text;
    public List<GameObject> note_list;
    public List<NumberData> all_Number_Dates;
    private bool toggle_note;
    private bool toggle_erase;
    private int num = 0;
    private int correct_num = 0;

    private bool selected = false;
    private int square_index = -1;
    private bool default_value = false;
    private bool is_wrong = false;
    private Sequence hintAnimation;
    public bool Is_correct() { return num == correct_num; }
    public bool Wrong_Square_Value(){ return is_wrong; }

    public void Set_Default_Value(bool deflt){ default_value = deflt; }
    public bool Get_Default_Value() { return default_value; }

    void Start()
    {
        toggle_note = false;
        toggle_erase = false;
        selected = IsSelected();
        selected = false;
        Set_Note(0);
        SetClearNotes();
    }

    //public List<string> Get_Note() { 
    //    List<string> notes = new List<string>();
    //    foreach (var number in note_list) {
    //        notes.Add(number.GetComponent<Text>().text);
    //    }
    //    return notes;
    //}

    private void SetClearNotes()
    {
        foreach (var number in note_list)
        {
            number.SetActive(false);
        }   
    }

    private void Set_Note(int value) 
    {
        foreach (var number in note_list)
        {
            if(value <= 0)
                number.SetActive(false);
            else
                number.SetActive(true);
        }
    }

    private void SetOneNumberNote(int value, bool update = false)
    {
        if (toggle_note == false && update == false)
        {
            return;
        }
        if (value <= 0)
        {
            foreach (GameObject number in note_list)
            {
                number.SetActive(false);
            }
        }
        else
        {
            if (!note_list[value - 1].activeSelf || update)
            {
                note_list[value - 1].SetActive(true);
            }
            else
            {
                note_list[value - 1].SetActive(false);
            }
        }
    }

    public void SetGridNotes(List<int> notes)
    {
        foreach (var note in notes)
        {
            SetOneNumberNote(note, true);
        }
    }

    public void On_Toggle_Note(bool active)
    {
        toggle_note = active;
    }

    public void On_Toggle_Erase()
    {
        if (selected && !default_value)
        {
            //Check is current value note or just value and add turn
            List<int> noteCount = new List<int>();

            for (int i = 0; i < note_list.Count; i++)
            {
                if (note_list[i].activeSelf)
                {
                    noteCount.Add(i + 1);
                }
            }

            if (noteCount.Count > 0)
            {
                GameTurnController.Instance.AddEraseTurn(this, true, 0, noteCount);
            }
            else
            {
                GameTurnController.Instance.AddEraseTurn(this, false, num, noteCount);
            }



            if (is_wrong)
                Set_Square_Colour(Color.white);
            is_wrong = false;
            SetNumber(0);
            Set_Note(0);
            DisplayText();
        }
    }

    public bool IsSelected() { return selected; }
    public void SetIndex(int index)
    {
        square_index = index;
    }

    public void SetCorrectNumber(int number)
    {
        correct_num = number;
        is_wrong = false;
    }
 
   public void DisplayText()
    {
        if (num <= 0)
        {
            Image image =  number_text.GetComponent<Image>();
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0);
            Set_Square_Colour(Color.white);
        }
        else
        {
            foreach (var item in all_Number_Dates)
            {
                if(num == item.number)
                {
                    number_text.GetComponent<Image>().sprite = item.fruitIcon;
                    number_text.GetComponent<Image>().color = Color.white;
                }
            }
        }
    }

    public void CancalSetNumberNote(int value, bool update = false)
    {
        if (!note_list[value - 1].activeSelf || update)
        {
            note_list[value - 1].SetActive(true);
        }
        else
        {
            note_list[value - 1].SetActive(false);
        }
    }

    public void CancallSetNumber(int number)
    {
        num = number;
        if (num != correct_num)
        {
            is_wrong = true;
            var colors = this.colors;
            colors.normalColor = Color.red;
            this.colors = colors;
            default_value = false;
        }
        else
        {
            is_wrong = false;
            default_value = true;
            var colors = this.colors;
            colors.normalColor = Color.white;
            this.colors = colors;
        }

        DisplayText();
    }

    public void SetNumber(int number)
    {
        num = number;

        DisplayText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hintAnimation != null) hintAnimation.Kill();

        selected = IsSelected();
        selected = true;
        Game_Events.Square_Selected_Func(square_index);
    }

    private void OnEnable()
    {
        Game_Events.On_Place_Number += OnSetNumber;
        Game_Events.On_Selected_Square += OnSelectedSquare;
        Game_Events.On_Notes_On += On_Toggle_Note;
        Game_Events.On_Erase_On += On_Toggle_Erase;
    }
    private void OnDisable()
    {
        Game_Events.On_Place_Number -= OnSetNumber;
        Game_Events.On_Selected_Square -= OnSelectedSquare;
        Game_Events.On_Notes_On -= On_Toggle_Note;
        Game_Events.On_Erase_On -= On_Toggle_Erase;
    }

    public void OnSetNumber(NumberData data)
    {
        selected = IsSelected();
        if (selected && default_value == false)
        {
            if(toggle_note == true && num == 0)
            {
                GameTurnController.Instance.AddNoteTurn(this, data.number);

                SetOneNumberNote(data.number);
            }
            else if(toggle_note == false)
            {
                //Check is Has Note, need to add NoteToSimpleTurn instead of SimpleTurn to the CameTurnController

                List<int> noteCount = new List<int>();

                for(int i = 0; i < note_list.Count; i++)
                {
                    if (note_list[i].activeSelf)
                    {
                        noteCount.Add(i + 1);
                    }
                }

                if(noteCount.Count > 0)
                {
                    GameTurnController.Instance.AddNoteToSimpleTurn(this, noteCount);
                }
                else
                {
                    //We save turn with last value on grid square
                    GameTurnController.Instance.AddSimpleTurn(this, num);
                }


                Set_Note(0);
                SetNumber(data.number);

                if (num != correct_num)
                {
                    is_wrong = true;
                    var colors = this.colors;
                    colors.normalColor = Color.red;
                    this.colors = colors;

                    if(DataController.Instanse.PlayerData.IsVibrationOn)
                        Handheld.Vibrate();

                    Game_Events.On_Wrong_Number_Func();
                }
                else
                {
                    is_wrong = false;
                    default_value = true;
                    var colors = this.colors;
                    colors.normalColor = Color.white;
                    this.colors = colors;
                    GameTurnController.Instance.SuccesfullSound();
                }

            }
            Game_Events.On_Check_Complete_Func();   // Check if game should be over
        }
    }

    public void OnSelectedSquare(int index)
    {
        if(square_index != index)
        {
            selected = IsSelected();
            selected = false;
        }
    }

    public void Set_Square_Colour(Color color)
    {
        var colours = this.colors;
        colours.normalColor = color;
        this.colors = colours;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void Hint()
    {
        foreach (var item in all_Number_Dates)
        {
            if (correct_num == item.number)
            {
                number_text.GetComponent<Image>().sprite = item.fruitIcon;
                number_text.GetComponent<Image>().color = Color.white;
            }
        }

        hintAnimation = DOTween.Sequence()
            .SetEase(Ease.OutSine)
            .Append(number_text.transform.DOScale(1.4f, 1f))
            .Append(number_text.transform.DOScale(0.9f, 1f))
            .SetLoops(3)
            .OnComplete(() =>
            {
                number_text.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                Image image = number_text.GetComponent<Image>();
                image.sprite = null;
                image.color = new Color(1, 1, 1, 0);
                Set_Square_Colour(Color.white);

            }).OnKill(() =>
            {
                number_text.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                Image image = number_text.GetComponent<Image>();
                image.sprite = null;
                image.color = new Color(1, 1, 1, 0);
                Set_Square_Colour(Color.white);
            });
    }
}
