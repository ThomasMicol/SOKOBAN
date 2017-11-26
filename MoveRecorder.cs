using System.Collections.Generic;
using System.Linq;

public class MoveRecorder : IMoveRecorder
{
    protected List<List<IEntity>> myMoves = new List<List<IEntity>>();

    public List<IEntity> GetLastMove(int moveNumber)
    {
        return myMoves[moveNumber - 1];
    }

    public List<IEntity> GetNextMove(int moveNumber)
    {
        return myMoves[moveNumber];
    }

    public List<List<IEntity>> GetMoveHistory()
    {
        return myMoves;
    }

    public void AddNewMove(int moveNumber, List<IEntity> levelData)
    {
        List<IEntity> l = new List<IEntity>();
        foreach(IEntity e in levelData)
        {
            l.Add(e.Clone());
        }
        myMoves.Insert(moveNumber, l);
        
    }

 


}