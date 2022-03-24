using Base.UserInterface;

namespace Game.UserInterfaces.InGame
{
    public class EndGameCanvas : BaseCanvas
    {
        public delegate void EndGameRequestDelegate();
        
        public event EndGameRequestDelegate OnReturnToMainMenuRequest;

        public void RequestReturnToMainMenu()
        {
            //TODO Handle EndGameCanvas
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}