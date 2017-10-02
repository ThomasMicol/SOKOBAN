using System.Collections.Generic;

public class Level
{
    protected int Id;
    protected int moveNumber = 0;
    protected int rowWidth;
    protected int columnHeight;
    protected bool complete;
    protected Entity[] levelData;
    protected IMoveRecorder moveRecorder;
    private int arrayAccession;


    public void SetMapDimensions(int width, int height)
    {
        rowWidth = width;
        columnHeight = height;
        int projectedEntityCount = (rowWidth * columnHeight);
        levelData = new Entity[projectedEntityCount];
        arrayAccession = 0;

    }

    public void SetMoveRecorder(IMoveRecorder aMoveRecorder)
    {
        moveRecorder = aMoveRecorder;
    }

    public void AddEntityToLevelData(Entity anEntity)
    {
        levelData[arrayAccession] = anEntity;
        arrayAccession++;
    }

    public bool CheckLevelDataLength()
    {
        if(levelData.Length == (rowWidth * columnHeight))
        {
            return true;
        }else
        {
            return false;
        }
    }

    public void MovePlayer(Directions aDir)
    {
        Entity player = levelData[0];
        Entity entityWhereImMovingTo = GetEntityAt(FindTargetLocation(player, aDir));
        Location playerLocation = new Location(player.GetLocation().x, player.GetLocation().y);
        Location entityLocation = new Location(entityWhereImMovingTo.GetLocation().x, entityWhereImMovingTo.GetLocation().y);
        //Location potentialPushLocation = new Location(pushLocationEntity.GetLocation().x, pushLocationEntity.GetLocation().y);
        moveRecorder.AddNewMove(new Movement(playerLocation, entityLocation));
        if (entityWhereImMovingTo.GetEntityType() == EntityTypes.MovableBlock)
        {
            Entity pushLocationEntity = GetEntityAt(FindTargetLocation(entityWhereImMovingTo, aDir));
            player.Move(aDir, entityWhereImMovingTo, pushLocationEntity);
        }
        else
        {
            player.Move(aDir, entityWhereImMovingTo);
        }
        
        if(CheckBoxGoalLocations())
        {
            complete = true;
        }
        moveNumber++;
    }

    public void UndoMove()
    {
        Movement lastMove = moveRecorder.GetLastMove(moveNumber);
        levelData[0].SetLocation(lastMove.GetStartingLocation());
        moveNumber--;
    }

    public void RedoMove()
    {
        Movement nextMove = moveRecorder.GetNextMove(moveNumber);
        levelData[0].SetLocation(nextMove.GetEndingLocation());
        moveNumber++;
    }

    public bool IsComplete()
    {
        return complete;
    }

    public Entity[] GetLevelData()
    {
        return levelData;
    }

    protected bool CheckBoxGoalLocations()
    {
        List<Entity> myBoxes = GetAllMovableBlocks();
        List<Entity> myGoals = GetAllGoals();
        bool levelIsComplete = true;
        foreach(Entity aBox in myBoxes)
        {
            foreach(Entity aGoal in myGoals)
            {
                
                if(aBox.GetLocation().x == aGoal.GetLocation().x && aBox.GetLocation().y == aGoal.GetLocation().y)
                {
                    levelIsComplete = true;
                }else{
                    levelIsComplete = false;
                    return levelIsComplete;
                }
            }
        }
        return levelIsComplete;
    }

    protected Entity GetEntityAt(Location targetLocation)
    {
        Entity backup = null;
        foreach(Entity anEntity in levelData)
        {
            Location anEntLocation = anEntity.GetLocation();
            if(anEntLocation.x == targetLocation.x && anEntLocation.y == targetLocation.y)
            {
                if(anEntity.GetEntityType() == EntityTypes.MovableBlock || anEntity.GetEntityType() == EntityTypes.Wall)
                {
                    return anEntity;
                }
                else
                {
                    backup = anEntity;
                }
            }
        }
        return backup;
    }

    protected List<Entity> GetAllMovableBlocks()
    {
        List<Entity> myBoxes = new List<Entity>();
        foreach(Entity anEntity in levelData)
        {
            if(anEntity.GetEntityType() == EntityTypes.MovableBlock)
            {
                myBoxes.Add(anEntity);
            }
        }
        return myBoxes;
    }

    protected List<Entity> GetAllGoals()
    {
        List<Entity> myGoals = new List<Entity>();
        foreach(Entity anEntity in levelData)
        {
            if(anEntity.GetEntityType() == EntityTypes.GoalTile)
            {
                myGoals.Add(anEntity);
            }
        }
        return myGoals;
    }

    protected Location FindTargetLocation(Entity startPoint, Directions aDir)
    {
        Location anEntityLocation = startPoint.GetLocation();

        Location newLocation = new Location(anEntityLocation.x, anEntityLocation.y);


        if(aDir == Directions.UP)
        {
            newLocation.y--;
        }
        if (aDir == Directions.DOWN)
        {
            newLocation.y++;
        }

        if (aDir == Directions.LEFT)
        {
            newLocation.x--;
        }
        if (aDir == Directions.RIGHT)
        {
            newLocation.x++;
        }

        return newLocation;

        

    }

    protected Entity FindTargetEntity(Location targetLocation)
    {
        foreach (Entity anEntity in levelData)
        {
            if (anEntity.GetLocation() == targetLocation)
            {
                return anEntity;
            }
        }
        return levelData[0];
    }

}