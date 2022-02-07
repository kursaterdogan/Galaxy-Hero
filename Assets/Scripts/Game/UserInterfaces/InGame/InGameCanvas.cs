using Base.UserInterface;

namespace Game.UserInterfaces.InGame
{
    public class InGameCanvas : BaseCanvas
    {
        public delegate void ReturnToMainMenuDelegate();

        public event ReturnToMainMenuDelegate OnReturnToMainMenu;

        public void RequestMainMenu()
        {
            //TODO Link with pause
            OnReturnToMainMenu?.Invoke();
        }
    }
}