using System.Collections.Generic;

public interface IMoveRecorder
{
    Movement GetLastMove(int moveNumber);
    Movement GetNextMove(int moveNumeber);
    List<Movement> GetMoveHistory();
    void AddNewMove(Movement aMove);
}