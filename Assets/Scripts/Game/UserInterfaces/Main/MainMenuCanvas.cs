using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class MainMenuCanvas : BaseCanvas
    {
        public delegate void MainMenuRequestDelegate();

        public event MainMenuRequestDelegate OnInGameRequest;
        public event MainMenuRequestDelegate OnSettingsRequest;
        public event MainMenuRequestDelegate OnGarageRequest;
        public event MainMenuRequestDelegate OnMarketRequest;
        public event MainMenuRequestDelegate OnInventoryRequest;
        public event MainMenuRequestDelegate OnSuperPowerRequest;
        public event MainMenuRequestDelegate OnCreditsRequest;
        public event MainMenuRequestDelegate OnQuoteRequest;

        public void RequestInGameMenu()
        {
            //TODO Add Provision canvas
            OnInGameRequest?.Invoke();
        }

        public void RequestQuote()
        {
            OnQuoteRequest?.Invoke();
        }

        public void RequestSettings()
        {
            OnSettingsRequest?.Invoke();
        }

        public void RequestGarage()
        {
            OnGarageRequest?.Invoke();
        }

        public void RequestMarket()
        {
            OnMarketRequest?.Invoke();
        }

        public void RequestInventory()
        {
            OnInventoryRequest?.Invoke();
        }

        public void RequestSuperPower()
        {
            OnSuperPowerRequest?.Invoke();
        }

        public void RequestCredits()
        {
            OnCreditsRequest?.Invoke();
        }
    }
}