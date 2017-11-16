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
        aLevel.SetMapDimensions(3, 5);
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
        for (int i = 0; i < 5; i++)
        {
            Entity leftWallEnt = new Entity(EntityTypes.Wall);
            Entity rightWallEnt = new Entity(EntityTypes.Wall);
            leftWallEnt.SetLocation(new Location(0, i));
            rightWallEnt.SetLocation(new Location(2, i));
            aLevel.AddEntityToLevelData(leftWallEnt);
            aLevel.AddEntityToLevelData(rightWallEnt);
        }
        Entity topMiddleWall = new Entity(EntityTypes.Wall);
        Entity bottomMiddleWall = new Entity(EntityTypes.Wall);
        topMiddleWall.SetLocation(new Location(1,0));
        bottomMiddleWall.SetLocation(new Location(1,4));
        aLevel.AddEntityToLevelData(bottomMiddleWall);
        aLevel.AddEntityToLevelData(topMiddleWall);

        Entity goal = new Entity(EntityTypes.GoalTile);
        goal.SetLocation(new Location(1, 1));
        aLevel.AddEntityToLevelData(goal);

        Entity box = new Entity(EntityTypes.MovableBlock);
        box.SetLocation(new Location(1, 2));
        aLevel.AddEntityToLevelData(box);

        return aLevel;



    }

    public bool SendLevel(Level aLevel)
    {
        throw new NotImplementedException();
    }
}