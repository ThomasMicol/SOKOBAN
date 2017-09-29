public class Level
{
    protected int Id;
    protected int moveNumber
    protected int rowWidth;
    protected int columnHeight;
    protected bool complete;
    protected Entity[] levelData;
    protected MoveRecorder moveRecorder;


    public void SetMapDimensions(int width, int height)
    {
        rowWidth = width;
        columnHeight = height;
        int projectedEntityCount = (rowWidth * columnHeight);
        levelData[] = new Entity[projectedEntityCount]

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

    public void MovePlayer(Directions aDir)
    {
        Entity entityWhereImMovingTo = GetEntityAt(targetLocation);
        levelData[0].Move(aDir, entityWhereImMovingTo);
    }

    public void UndoMove()
    {

    }

    public void RedoMove()
    {

    }

    protected Entity GetEntityAt(Location targetLocation)
    {
        foreach(Entity anEntity in levelData)
        {
            if(anEntity.location == targetLocation)
            {
                return anEntity;
            }
        }
    }

}