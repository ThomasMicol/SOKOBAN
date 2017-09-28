using System.Collections.Generic;

public interface IFileHander
{
    object GetLevel(int targetId);
    void SaveState(List<int> moveHistory);
    
}