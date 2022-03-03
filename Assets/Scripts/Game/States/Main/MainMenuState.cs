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
            _mainMenuCanvas.OnInGameRequest += RequestStartGame;
            _mainMenuCanvas.OnInventoryRequest += RequestInventory;
            _mainMenuCanvas.OnGarageRequest += RequestGarage;
            _mainMenuCanvas.OnSuperPowerRequest += RequestSuperPower;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnInGameRequest -= RequestStartGame;
            _mainMenuCanvas.OnInventoryRequest -= RequestInventory;
            _mainMenuCanvas.OnGarageRequest -= RequestGarage;
            _mainMenuCanvas.OnSuperPowerRequest -= RequestSuperPower;
        }

        private void RequestCredits()
        {
            SendTrigger((int)StateTriggers.GoToCredits);
        }

        private void RequestSuperPower()
        {
            //TODO Delete & Rename Unused Triggers 
            SendTrigger((int)StateTriggers.GoToSuperPower);
        }

        private void RequestInventory()
        {
            SendTrigger((int)StateTriggers.GoToInventory);
        }

        private void RequestGarage()
        {
            SendTrigger((int)StateTriggers.GoToGarage);
        }

        private void RequestSettingsMenu()
        {
            SendTrigger((int)StateTriggers.GoToSettings);
        }

        private void RequestQuote()
        {
            SendTrigger((int)StateTriggers.GoToQuote);
        }

        private void RequestStartGame()
        {
            SendTrigger((int)StateTriggers.StartGame);
        }
    }
}