using System;

public class GameController
{
    protected IView theView;
    public Level theLevel;
    protected IFileHandlerAdapter fileHandlerAdapter;
    protected bool isPlaying;

    public GameController(IView aView)
    {
        fileHandlerAdapter = new FileHandlerAdapter();
        isPlaying = false;
        theView = aView;
        theView.DisplayMenu();
    }

    public void StartNewGame()
    {
        if(CheckLevelReady())
        {
            isPlaying = true;
            theLevel.SetMoveRecorder(new MoveRecorder());
            theView.ClearForm();
            theView.DrawGameControls();
            theView.RedrawLevel();
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
            theView.DisplaySystemMessage("Level Save Failed");
        }
    }

    public void LoadLevel(string filePath)
    {
        theLevel = fileHandlerAdapter.RequestLevel(filePath);
    }

    public void MovePlayer(Directions aDir)
    {
        theLevel.MovePlayer(aDir);
        theView.RedrawLevel();
    }

    public void UndoMove()
    {
        theLevel.UndoMove();
        theView.RedrawLevel();
    }

    public void RedoMove()
    {
        theLevel.RedoMove();
        theView.RedrawLevel();
    }

    public bool CheckLevelComplete()
    {
        return theLevel.IsComplete();
    }

    protected bool CheckLevelReady()
    {
        if(theLevel != null)
        {
            if (theLevel.CheckLevelDataLength())
            {
                return true;
            }
            else
            {
                theView.DisplaySystemMessage("The level save is corrupt");
                theLevel = null;
                return false;
            }
        }
        return false;
        
        
    }


}
