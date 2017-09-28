public class FileHandlerAdapter : IFileHandlerAdapter
{
    protected IFileHandler fileHandler;

    public FileHandlerAdapter(){
        fileHandler = new IFileHandler();
    }

    public Level RequestLevel(string filePath)
    {

    }

    public bool SendLevel(Level aLevel)
    {

    }
}