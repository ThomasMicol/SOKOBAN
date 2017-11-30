using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileHandler : IFileHandler
{
    public object GetLevel(int targetId)
    {
        throw new NotImplementedException();
    }

    public void SaveState(List<int> moveHistory)
    {
        Console.WriteLine("Saved");
    }
}

