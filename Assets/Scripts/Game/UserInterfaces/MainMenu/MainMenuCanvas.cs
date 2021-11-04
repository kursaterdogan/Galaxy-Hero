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

        public void RequestQuoteMenu()
        {
            if (OnQuoteMenuRequest != null)
            {
                OnQuoteMenuRequest();
            }
        }

        public void RequestSettingsMenu()
        {
            if (OnSettingsMenuRequest != null)
            {
                OnSettingsMenuRequest();
            }
        }

        public void RequestAchievementsMenu()
        {
            if (OnAchievementsMenuRequest != null)
            {
                OnAchievementsMenuRequest();
            }
        }

        public void RequestMarketMenu()
        {
            if (OnMarketMenuRequest != null)
            {
                OnMarketMenuRequest();
            }
        }

        public void RequestInventoryMenu()
        {
            if (OnInventoryMenuRequest != null)
            {
                OnInventoryMenuRequest();
            }
        }

        public void RequestGarageMenu()
        {
            if (OnGarageMenuRequest != null)
            {
                OnGarageMenuRequest();
            }
        }

        public void RequestCoPilotMenu()
        {
            if (OnCoPilotMenuRequest != null)
            {
                OnCoPilotMenuRequest();
            }
        }

        public void RequestCreditsMenu()
        {
            if (OnCreditsMenuRequest != null)
            {
                OnCreditsMenuRequest();
            }
        }
    }
}