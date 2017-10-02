public interface IFileHandlerAdapter
{
    Level RequestLevel(string filePath);
    bool SendLevel(Level aLevel);

}