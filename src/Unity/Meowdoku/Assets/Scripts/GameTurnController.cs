using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GameTurnController : MonoBehaviour
{
    public static GameTurnController Instance;

    private List<ITurn> Turns = new List<ITurn>();
    public AudioSource succesfullSound;

    public void Awake()
    {
        Instance = this;        
    }

    public void AddSimpleTurn(Grid_Square square, int number)
    {
        SimpleTurn simpleTurn = new SimpleTurn()
        {
            Square = square,
            Number = number
        };

        Turns.Add(simpleTurn);
    }
    public void AddNoteTurn(Grid_Square square, int number)
    {
        NoteTurn simpleTurn = new NoteTurn()
        {
            Square = square,
            Number = number
        };

        Turns.Add(simpleTurn);
    }
    public void AddNoteToSimpleTurn(Grid_Square square, List<int> numbers)
    {
        NoteToSimpleTurn simpleTurn = new NoteToSimpleTurn()
        {
            Square = square,
            NoteNumbers = numbers
        };

        Turns.Add(simpleTurn);
    }
    public void AddEraseTurn(Grid_Square square, bool isNote, int number, List<int> noteNumbers)
    {
        EraseTurn simpleTurn = new EraseTurn()
        {
            Square = square,
            IsNote = isNote,
            Number = number,
            NoteNumbers = noteNumbers
        };

        Turns.Add(simpleTurn);
    }
    public void Cancell()
    {
        if (Turns.Count == 0) return;

        ITurn lastTurn = Turns[Turns.Count - 1];

        if(lastTurn is SimpleTurn simpleTurn)
        {
            simpleTurn.Square.CancallSetNumber(simpleTurn.Number);
        }
        else if(lastTurn is NoteTurn NoteTurn)
        {
            NoteTurn.Square.CancalSetNumberNote(NoteTurn.Number);
        }
        else if(lastTurn is NoteToSimpleTurn NoteToSimpleTurn)
        {
            NoteToSimpleTurn.Square.CancallSetNumber(0);

            foreach(int noteValue in NoteToSimpleTurn.NoteNumbers)
            {
                NoteToSimpleTurn.Square.CancalSetNumberNote(noteValue);
            }
        }
        else if(lastTurn is EraseTurn eraseTurn)
        {
            if(eraseTurn.IsNote)
            {
                eraseTurn.Square.CancallSetNumber(0);

                foreach (int noteValue in eraseTurn.NoteNumbers)
                {
                    eraseTurn.Square.CancalSetNumberNote(noteValue);
                }
            }
            else
            {
                eraseTurn.Square.CancallSetNumber(eraseTurn.Number);
            }
        }
        Turns.Remove(lastTurn);
    }

    public void SuccesfullSound()
    {
        succesfullSound.Play();
    }
}


public interface ITurn
{

}

public struct SimpleTurn : ITurn
{
    public Grid_Square Square;
    public int Number;
}

public struct NoteTurn : ITurn
{
    public Grid_Square Square;
    public int Number;
}

public struct NoteToSimpleTurn : ITurn
{
    public Grid_Square Square;
    public List<int> NoteNumbers;
}
public struct EraseTurn : ITurn
{
    public Grid_Square Square;
    public bool IsNote;
    public int Number;
    public List<int> NoteNumbers;

}