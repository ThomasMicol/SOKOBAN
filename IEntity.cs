using Assignment1___Thomas_Micol;

public interface IEntity
{
    Location GetLocation();
    void SetLocation(Location aLocation);
    void SetLocationY(Directions aDir);
    void SetLocationX(Directions aDir);
    bool GetIsSolid();
    EntityTypes GetEntityType();
    void Move(Directions aDir, IEntity targetEntity, IEntity potentialPushToEntity);
    void Move(Directions aDir, IEntity targetEntity);
    void Move(Directions aDir);
    void AttachNewObserver(IEntity observer);
    void DetachObserver(IEntity observer);
    void Notify();


}