using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class MainMenuState : StateMachine, IRequestable
    {
        private UIComponent _uiComponent;

        private MainMenuCanvas _mainMenuCanvas;

        public MainMenuState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;

            _mainMenuCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.MainMenu) as MainMenuCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToCanvasRequestDelegates();

            _uiComponent.EnableCanvas(UIComponent.MenuName.MainMenu);
        }

        protected override void OnExit()
        {
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnInventoryRequest += RequestInventory;
            _mainMenuCanvas.OnGarageRequest += RequestGarage;
            _mainMenuCanvas.OnSuperPowerRequest += RequestSuperPower;
            _mainMenuCanvas.OnCreditsRequest += RequestCredits;
            _mainMenuCanvas.OnInGameRequest += RequestStartGame;
            _mainMenuCanvas.OnSettingsRequest += RequestSettings;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnInventoryRequest -= RequestInventory;
            _mainMenuCanvas.OnGarageRequest -= RequestGarage;
            _mainMenuCanvas.OnSuperPowerRequest -= RequestSuperPower;
            _mainMenuCanvas.OnCreditsRequest -= RequestCredits;
            _mainMenuCanvas.OnInGameRequest -= RequestStartGame;
            _mainMenuCanvas.OnSettingsRequest -= RequestSettings;
        }

        private void RequestInventory()
        {
            SendTrigger((int)StateTriggers.GoToInventory);
        }

        private void RequestGarage()
        {
            SendTrigger((int)StateTriggers.GoToGarage);
        }

        private void RequestSuperPower()
        {
            SendTrigger((int)StateTriggers.GoToSuperPower);
        }

        private void RequestCredits()
        {
            SendTrigger((int)StateTriggers.GoToCredits);
        }

        private void RequestSettings()
        {
            SendTrigger((int)StateTriggers.GoToSettings);
        }

        private void RequestStartGame()
        {
            SendTrigger((int)StateTriggers.StartGame);
        }
    }
}