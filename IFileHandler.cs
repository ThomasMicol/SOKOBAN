using System.Collections.Generic;

public interface IFileHandler
{
    object GetLevel(int targetId);
    void SaveState(List<int> moveHistory);
    
}