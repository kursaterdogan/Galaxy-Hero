using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class SuperPowerCanvas : BaseCanvas
    {
        public delegate void SuperPowerRequestDelegate();

        public event SuperPowerRequestDelegate OnReturnToMainMenuRequest;

        public void RequestReturnToMainMenu()
        {
            //TODO Handle SuperPowerCanvas
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}