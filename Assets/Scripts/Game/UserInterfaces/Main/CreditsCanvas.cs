using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class CreditsCanvas : BaseCanvas
    {
        public delegate void CreditsRequestDelegate();

        public event CreditsRequestDelegate OnReturnToMainMenuRequest;

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}