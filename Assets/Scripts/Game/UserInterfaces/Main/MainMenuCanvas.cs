using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class MainMenuCanvas : BaseCanvas
    {
        public delegate void MainMenuRequestDelegate();

        public event MainMenuRequestDelegate OnInventoryRequest;
        public event MainMenuRequestDelegate OnGarageRequest;
        public event MainMenuRequestDelegate OnSuperPowerRequest;
        public event MainMenuRequestDelegate OnCreditsRequest;
        public event MainMenuRequestDelegate OnAchievementRequest;
        public event MainMenuRequestDelegate OnInGameRequest;

        public void RequestInventory()
        {
            OnInventoryRequest?.Invoke();
        }

        public void RequestGarage()
        {
            OnGarageRequest?.Invoke();
        }

        public void RequestSuperPower()
        {
            OnSuperPowerRequest?.Invoke();
        }

        public void RequestCredits()
        {
            OnCreditsRequest?.Invoke();
        }

        public void RequestAchievement()
        {
            OnAchievementRequest?.Invoke();
        }

        public void RequestInGameMenu()
        {
            //TODO Add Provision canvas
            OnInGameRequest?.Invoke();
        }
    }
}