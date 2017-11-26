using System;

public class FileHandlerAdapter : IFileHandlerAdapter
{
    protected IFileHandler fileHandler;

    public FileHandlerAdapter(){
        fileHandler = new FileHandler();
    }

    public Level RequestLevel(string filePath)
    {
        Level aLevel = new Level();
        aLevel.SetMapDimensions(18, 80);
        aLevel.SetMoveRecorder(new MoveRecorder());

        IEntity player = new Entity(EntityTypes.Player);
        player.SetLocation(new Location(1, 3));
        aLevel.AddEntityToLevelData(player);

        //for(int i = 0; i < 5; i++)
        //{
        //    for(int x = 0; x < 3; x++)
        //    {
        //        Entity floor = new Entity(EntityTypes.Floor);
        //        floor.SetLocation(new Location(x, i));
        //        aLevel.AddEntityToLevelData(floor);
        //    }
        //}
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
        
        //for (int i = 0; i < 5; i++)
        //{
        //    Entity leftWallEnt = new Entity(EntityTypes.Wall);
        //    Entity rightWallEnt = new Entity(EntityTypes.Wall);
        //    leftWallEnt.SetLocation(new Location(0, i));
        //    rightWallEnt.SetLocation(new Location(2, i));
        //    aLevel.AddEntityToLevelData(leftWallEnt);
        //    aLevel.AddEntityToLevelData(rightWallEnt);
        //}
        //Entity topMiddleWall = new Entity(EntityTypes.Wall);
        //Entity bottomMiddleWall = new Entity(EntityTypes.Wall);
        //topMiddleWall.SetLocation(new Location(1,0));
        //bottomMiddleWall.SetLocation(new Location(1,4));
        //aLevel.AddEntityToLevelData(bottomMiddleWall);
        //aLevel.AddEntityToLevelData(topMiddleWall);

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
        throw new NotImplementedException();
    }
}