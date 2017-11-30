public interface IView
{
    void DisplayMenu();
    void RedrawLevel();
    void DrawGameControls();
    void DisplaySystemMessage(string msg);
    void PlayWinningSound();
    void ClearForm();
    void SetController(GameController gameController);
    void Run();
}