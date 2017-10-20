public interface IView
{
    void DisplayMenu();
    void RedrawLevel();
    void DrawGameControls();
    void DisplaySystemMessage(string msg);
    void PlayWinningSound();
    void ClearForm();
}