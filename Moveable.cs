using System;
public class Movable : Entity
{
    public void Move(Directions aDir, Entity targetEntity)
    {
        
        if(aDir == Directions.UP || aDir == Directions.DOWN)
        {
            HandleYMovement(aDir, targetEntity);
        }
        else
        {
            HandleXMovement(aDir, targetEntity);
        }
    }

    protected void HandleXMovement(Directions aDir, Entity targetEntity)
    {
        if(targetEntity.isSolid == false){
            base.location.x += aDir;
        }
        else
        {
            if(targetEntity.GetType() == typeof(MovableBlock))
            {
                base.location.x += aDir;
                targetEntity.move(aDir);
            }else{
                return;
            }
        }
        
        
    }

    protected void HandleYMovement(Directions aDir, Entity targetEntity)
    {
        if(targetEntity.isSolid == false){
            base.location.y += aDir;
        }
        else
        {
            if(targetEntity.GetType() == typeof(MovableBlock))
            {
                base.location.y += aDir;
                targetEntity.move(aDir);
            }else{
                return;
            }
        }
    }
}