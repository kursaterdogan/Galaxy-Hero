using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class SettingsCanvas : BaseCanvas
    {
        public delegate void SettingsRequestDelegate();

        public event SettingsRequestDelegate OnReturnToMainMenuRequest;

        public void RequestReturnToMainMenu()
        {
            //TODO Handle SettingsCanvas
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}
