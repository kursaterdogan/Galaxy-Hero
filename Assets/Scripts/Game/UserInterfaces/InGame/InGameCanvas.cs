using Base.UserInterface;

namespace Game.UserInterfaces.InGame
{
    public class InGameCanvas : BaseCanvas
    {
        public delegate void InGameRequestDelegate();
        
        public event InGameRequestDelegate OnReturnToMainMenuRequest;

        public void RequestReturnToMainMenu()
        {
            //TODO Handle InGameCanvas
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}