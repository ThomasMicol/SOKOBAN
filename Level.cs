public class Level
{
    protected int Id;
    protected int rowWidth;
    protected int columnHeight;
    protected bool complete;
    protected Entity[] levelData;
    protected MoveRecorder moveRecorder;


    public void SetMapDimensions(int width, int height)
    {
        rowWidth = width;
        columnHeight = height;

    }

    public void SetMoveRecorder(IMoveRecorder aMoveRecorder)
    {
        moveRecorder = aMoveRecorder;
    }

    public void AddEntityToLevelData(Entity anEntity)
    {
        levelData.add(anEntity);
    }

    public bool CheckLevelDataLength()
    {
        if(levelData.length === (rowWidth * columnHeight))
        {
            return true;
        }else
        {
            return false;
        }

    }

}