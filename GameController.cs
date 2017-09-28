using System;

public class GameController
{
    protected IView view;
    protected Level level;
    protected IFileHandler fileHandler;
    protected bool isPlaying;

    public GameController(IView aView)
    {
        isPlaying = false;
        view = aView;
    }

    public void StartNewGame()
    {
        throw new NotImplementedException("StartNewGame not implemented");
    }

    public void LoadLevel()
    {
        throw new NotImplementedException("Load Level has yet to be implemented");
    }

    public void LevelComplete()
    {
        throw new NotImplementedException("levelComplete not implemented");
    }

    protected void SaveGame()
    {
        throw new NotImplementedException("save has not been implemented");
    }


}
