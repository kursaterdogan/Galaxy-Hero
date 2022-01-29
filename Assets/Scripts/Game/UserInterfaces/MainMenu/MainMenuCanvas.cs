namespace Game.UserInterfaces.MainMenu
{
    using Base.UserInterface;

    public class MainMenuCanvas : BaseCanvas
    {
        public delegate void MenuRequestDelegate();

        public event MenuRequestDelegate OnInGameMenuRequest;
        public event MenuRequestDelegate OnSettingsMenuRequest;
        public event MenuRequestDelegate OnAchievementsMenuRequest;
        public event MenuRequestDelegate OnMarketMenuRequest;
        public event MenuRequestDelegate OnInventoryMenuRequest;
        public event MenuRequestDelegate OnGarageMenuRequest;
        public event MenuRequestDelegate OnCoPilotMenuRequest;
        public event MenuRequestDelegate OnCreditsMenuRequest;
        public event MenuRequestDelegate OnQuoteMenuRequest;

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