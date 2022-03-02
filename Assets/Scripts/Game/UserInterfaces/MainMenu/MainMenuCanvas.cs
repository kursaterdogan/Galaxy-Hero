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

        public void RequestQuote()
        {
            OnQuoteMenuRequest?.Invoke();
        }

        public void RequestSettings()
        {
            OnSettingsMenuRequest?.Invoke();
        }

        public void RequestAchievements()
        {
            OnAchievementsMenuRequest?.Invoke();
        }

        public void RequestMarket()
        {
            OnMarketMenuRequest?.Invoke();
        }

        public void RequestInventory()
        {
            OnInventoryMenuRequest?.Invoke();
        }

        public void RequestGarage()
        {
            OnGarageMenuRequest?.Invoke();
        }

        public void RequestCoPilot()
        {
            OnCoPilotMenuRequest?.Invoke();
        }

        public void RequestCredits()
        {
            OnCreditsMenuRequest?.Invoke();
        }
    }
}