using System.Collections.Generic;

public interface IMoveRecorder
{
    List<IEntity> GetLastMove(int moveNumber);
    List<IEntity> GetNextMove(int moveNumeber);
    List<List<IEntity>> GetMoveHistory();
    void AddNewMove(List<IEntity> levelData);
}