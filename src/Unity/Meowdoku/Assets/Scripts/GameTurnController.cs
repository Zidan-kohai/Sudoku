using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTurnController : MonoBehaviour
{
    public static GameTurnController Instance;

    private List<ITurn> Turns = new List<ITurn>();


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


    public void Cancell()
    {
        if (Turns.Count == 0) return;

        ITurn lastTurn = Turns[Turns.Count - 1];

        if(lastTurn is SimpleTurn turn)
        {
            turn.Square.CancallSetNumber(turn.Number);
        }
        else if(lastTurn is NoteTurn)
        {

        }
        else if(lastTurn is NoteToSimpleTurn)
        {

        }

        Turns.Remove(lastTurn);
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