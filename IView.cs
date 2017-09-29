public interface IView
{
    void DisplayClean();
    void DisplayElement(Location location, Entity entity);
    void DisplayBackground();
    void DisplayLevelGrid();
    void DisplayDirectionArrow(Directions direction);
    void DisplayPlayerStructItem(Entity entity);
    void DisplayWinScreen();
    void SoundPlayerStruckItem(Entity entity);
    void OnKeyPress(object sender, Event e);
    void ErrorMessage(string errorMessage);
    void DisplaySystemMessage(string message);
    void Redraw();


}