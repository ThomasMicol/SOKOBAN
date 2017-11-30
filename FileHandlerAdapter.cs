using System.Collections.Generic;

public class FileHandlerAdapter : IFileHandlerAdapter
{
    protected IFileHandler fileHandler;

    public FileHandlerAdapter(){
        fileHandler = new FileHandler();
    }

    public Level RequestLevel(string filePath)
    {
        Level aLevel = new Level();
        aLevel.SetMapDimensions(8, 8);
        aLevel.SetMoveRecorder(new MoveRecorder());

        IEntity player = new Entity(EntityTypes.Player);
        player.SetLocation(new Location(1, 3));
        aLevel.AddEntityToLevelData(player);
        
        for(int levelHeight = 0; levelHeight < aLevel.GetColumnHeight(); levelHeight++)
        {
            for (int levelWidth = 0; levelWidth < aLevel.GetRowWidth(); levelWidth++)
            {
                if (levelHeight == 0 || levelWidth == 0 || levelWidth == aLevel.GetRowWidth() - 1 || levelHeight == aLevel.GetColumnHeight() - 1)
                {
                    IEntity sideWall = new Entity(EntityTypes.Wall);
                    sideWall.SetLocation(new Location(levelWidth, levelHeight));
                    aLevel.AddEntityToLevelData(sideWall);

                }
                
            }
        }

        Entity goal = new Entity(EntityTypes.GoalTile);
        goal.SetLocation(new Location(5, 4));
        aLevel.AddEntityToLevelData(goal);

        Entity box = new Entity(EntityTypes.MovableBlock);
        box.SetLocation(new Location(4, 2));
        aLevel.AddEntityToLevelData(box);

        Entity box1 = new Entity(EntityTypes.MovableBlock);
        box1.SetLocation(new Location(4, 5));
        aLevel.AddEntityToLevelData(box1);

        return aLevel;



    }

    public bool SendLevel(Level aLevel)
    {
        //Conversion would take place here changing the
        //incompatible data type into a compatible data type.

        fileHandler.SaveState(new List<int>());
        return true;
    }
}