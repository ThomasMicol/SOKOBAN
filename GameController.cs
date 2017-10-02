using System;

public class GameController
{
    protected IView theView;
    protected Level theLevel;
    protected IFileHandlerAdapter fileHandlerAdapter;
    protected bool isPlaying;

    public GameController(IView aView)
    {
        fileHandlerAdapter = new FileHandlerAdapter();
        isPlaying = false;
        theView = aView;
    }

    public void StartNewGame()
    {
        if(CheckLevelReady())
        {
            isPlaying = true;
            theLevel.SetMoveRecorder(new MoveRecorder());
        }
    }

    public void StartGameFromLastState()
    {
        if(CheckLevelReady())
        {
            isPlaying = true;
        }
    }

    public void SaveLevelState()
    {
        if(fileHandlerAdapter.SendLevel(theLevel))
        {
            theView.DisplaySystemMessage("Level Saved Correctly");
        }
        else
        {
            theView.ErrorMessage("Level Save Failed");
        }
    }

    public void LoadLevel(string filePath)
    {
        theLevel = fileHandlerAdapter.RequestLevel(filePath);
    }

    public void MovePlayer(Directions aDir)
    {
        theLevel.MovePlayer(aDir);
        theView.Redraw();
    }

    public void UndoMove()
    {
        theLevel.UndoMove();
        theView.Redraw();
    }

    public void RedoMove()
    {
        theLevel.RedoMove();
        theView.Redraw();
    }

    public bool CheckLevelComplete()
    {
        return theLevel.IsComplete();
    }

    protected bool CheckLevelReady()
    {
        if(theLevel.CheckLevelDataLength())
        {
            return true;
        }
        else
        {
            theView.ErrorMessage("The level save is corrupt");
            theLevel = null;
            return false;
        }
    }


}
