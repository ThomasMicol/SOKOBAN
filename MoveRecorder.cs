using System.Collections.Generic;

public class MoveRecorder : IMoveRecorder
{
    protected List<Movement> myMoves = new List<Movement>();
    protected int numberOfMoves;

    public Movement GetLastMove(int moveNumber)
    {
        return myMoves[moveNumber - 1];
    }

    public Movement GetNextMove(int moveNumber)
    {
        {
            return myMoves[moveNumber];
        }
    }

    public List<Movement> GetMoveHistory()
    {
        return myMoves;
    }

    public void AddNewMove(Movement aMove)
    {
        myMoves.Insert(numberOfMoves, aMove);
        numberOfMoves = myMoves.Count;
    }


}