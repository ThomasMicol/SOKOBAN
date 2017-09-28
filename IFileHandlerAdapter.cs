public interface IFileHandlerAdapter
{
    Level requestLevel(string filePath);
    bool sendLevel(Level aLevel);

}