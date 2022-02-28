using Base.UserInterface;

namespace Game.UserInterfaces.MainMenu
{
    public class MainMenuCanvas : BaseCanvas
    {
        public delegate void MainMenuRequestDelegate();

        public event MainMenuRequestDelegate OnInGameMenuRequest;
        public event MainMenuRequestDelegate OnSettingsMenuRequest;
        public event MainMenuRequestDelegate OnAchievementsMenuRequest;
        public event MainMenuRequestDelegate OnMarketMenuRequest;
        public event MainMenuRequestDelegate OnInventoryMenuRequest;
        public event MainMenuRequestDelegate OnGarageMenuRequest;
        public event MainMenuRequestDelegate OnCoPilotMenuRequest;
        public event MainMenuRequestDelegate OnCreditsMenuRequest;
        public event MainMenuRequestDelegate OnQuoteMenuRequest;

        public void RequestInGameMenu()
        {
            //TODO Add Provision canvas
            OnInGameMenuRequest?.Invoke();
        }

        public void RequestQuoteMenu()
        {
            OnQuoteMenuRequest?.Invoke();
        }

        public void RequestSettingsMenu()
        {
            OnSettingsMenuRequest?.Invoke();
        }

        public void RequestAchievementsMenu()
        {
            OnAchievementsMenuRequest?.Invoke();
        }

        public void RequestMarketMenu()
        {
            OnMarketMenuRequest?.Invoke();
        }

        public void RequestInventoryMenu()
        {
            OnInventoryMenuRequest?.Invoke();
        }

        public void RequestGarageMenu()
        {
            OnGarageMenuRequest?.Invoke();
        }

        public void RequestCoPilotMenu()
        {
            OnCoPilotMenuRequest?.Invoke();
        }

        public void RequestCreditsMenu()
        {
            OnCreditsMenuRequest?.Invoke();
        }
    }
}