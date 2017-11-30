using System;
using System.Collections.Generic;

public class Level
{
    protected int Id;
    protected int moveNumber = 0;
    protected int maxMoveNumber = 0;
    protected int rowWidth;
    protected int columnHeight;
    protected bool complete;
    protected List<IEntity> levelData = new List<IEntity>();
    protected IMoveRecorder moveRecorder;


    public void SetMapDimensions(int width, int height)
    {
        rowWidth = width;
        columnHeight = height;
        int projectedEntityCount = (rowWidth * columnHeight);

    }

    public int GetRowWidth()
    {
        return rowWidth;
    }

    public int GetColumnHeight()
    {
        return columnHeight;
    }

    internal int GetMoveCount()
    {
        return moveNumber;
    }

    public void SetMoveRecorder(IMoveRecorder aMoveRecorder)
    {
        moveRecorder = aMoveRecorder;
    }

    public void AddEntityToLevelData(IEntity anEntity)
    {
        if(anEntity.GetEntityType() != EntityTypes.Player && anEntity.GetEntityType() != EntityTypes.Floor && anEntity.GetEntityType() != EntityTypes.Void)
        {
            levelData[0].AttachNewObserver(anEntity);
        }
        levelData.Add(anEntity);
    }

    public bool CheckLevelDataLength()
    {
        return true;
    }

    public void MovePlayer(Directions aDir)
    {
        moveRecorder.AddNewMove(moveNumber, levelData);
        IEntity player = levelData[0];
        IEntity entityWhereImMovingTo = GetEntityAt(FindTargetLocation(player, aDir));
        Location playerLocation = new Location(player.GetLocation().x, player.GetLocation().y);
        if (entityWhereImMovingTo != null)
        {
            Location entityLocation = new Location(entityWhereImMovingTo.GetLocation().x, entityWhereImMovingTo.GetLocation().y);
            
            if(moveNumber == maxMoveNumber)
            {
                moveNumber++;
                maxMoveNumber++;
            }
            else
            {
                moveNumber++;
            }
            
            if (entityWhereImMovingTo.GetEntityType() == EntityTypes.GoalTile)
            {
                if (GetOverlappingEntity(entityWhereImMovingTo) != null)
                {
                    player.Move(aDir);
                }
            }
            if (entityWhereImMovingTo.GetEntityType() == EntityTypes.MovableBlock)
            {
                IEntity pushLocationEntity = GetEntityAt(FindTargetLocation(entityWhereImMovingTo, aDir));
                player.Move(aDir, entityWhereImMovingTo, pushLocationEntity);
            }
            else
            {
                player.Move(aDir, entityWhereImMovingTo);
            }
        }
        else
        {
            player.Move(aDir);
            moveNumber++;
            maxMoveNumber++;
        }

        


        if (CheckBoxGoalLocations())
        {
            complete = true;
        }
        
    }

    protected IEntity GetOverlappingEntity(IEntity e)
    {
        foreach(IEntity i in levelData)
        {
            if(i.GetLocation().x == e.GetLocation().x && i.GetLocation().y == e.GetLocation().y)
            {
                if(i.GetEntityType() != e.GetEntityType())
                {
                    return i;
                }
            }
        }
        return null;
    }

    public void UndoMove()
    {
        if (moveNumber > 0)
        {
            List<IEntity> data = moveRecorder.GetLastMove(moveNumber);
            levelData = null;
            levelData = data;
            moveNumber--;
        }
    }

    public void RedoMove()
    {
        if(moveNumber < maxMoveNumber)
        {
            List<IEntity> data = moveRecorder.GetNextMove(moveNumber);
            levelData = null;
            levelData = data;
            moveNumber++;
        }
        
    }

    public bool IsComplete()
    {
        return complete;
    }

    public List<IEntity> GetLevelData()
    {
        return levelData;
    }

    protected bool CheckBoxGoalLocations()
    {
        List<IEntity> myBoxes = GetAllMovableBlocks();
        List<IEntity> myGoals = GetAllGoals();
        bool levelIsComplete = true;
        foreach(IEntity aBox in myBoxes)
        {
            foreach(IEntity aGoal in myGoals)
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

    protected IEntity GetEntityAt(Location targetLocation)
    {
        IEntity backup = null;
        foreach(IEntity anEntity in levelData)
        {
            Location anEntLocation = anEntity.GetLocation();
            if(anEntLocation.x == targetLocation.x && anEntLocation.y == targetLocation.y)
            {
                return anEntity; 
            }
        }
        return backup;
        
    }

    protected List<IEntity> GetAllMovableBlocks()
    {
        List<IEntity> myBoxes = new List<IEntity>();
        foreach(IEntity anEntity in levelData)
        {
            if(anEntity.GetEntityType() == EntityTypes.MovableBlock)
            {
                myBoxes.Add(anEntity);
            }
        }
        return myBoxes;
    }

    protected List<IEntity> GetAllGoals()
    {
        List<IEntity> myGoals = new List<IEntity>();
        foreach(IEntity anEntity in levelData)
        {
            if(anEntity.GetEntityType() == EntityTypes.GoalTile)
            {
                myGoals.Add(anEntity);
            }
        }
        return myGoals;
    }

    protected Location FindTargetLocation(IEntity startPoint, Directions aDir)
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

    protected IEntity FindTargetEntity(Location targetLocation)
    {
        foreach (IEntity anEntity in levelData)
        {
            if (anEntity.GetLocation() == targetLocation)
            {
                return anEntity;
            }
        }
        return levelData[0];
    }

}