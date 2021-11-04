namespace Game.States.Main
{
    using Base.Component;
    using Base.State;
    using Components;
    using UserInterfaces.MainMenu;
    using UnityEngine;

    public class MainMenuState : StateMachine
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
            _uiComponent.EnableCanvas(UIComponent.MenuName.MainMenu);
            _mainMenuCanvas.OnInGameMenuRequest += RequestInGameMenu;
            _mainMenuCanvas.OnSettingsMenuRequest += OnSettingsMenuRequest;
            _mainMenuCanvas.OnAchievementsMenuRequest += OnAchievementsMenuRequest;
            _mainMenuCanvas.OnMarketMenuRequest += OnMarketMenuRequest;
            _mainMenuCanvas.OnInventoryMenuRequest += OnInventoryMenuRequest;
            _mainMenuCanvas.OnGarageMenuRequest += OnGarageMenuRequest;
            _mainMenuCanvas.OnCoPilotMenuRequest += OnCoPilotMenuRequest;
            _mainMenuCanvas.OnCreditsMenuRequest += OnCreditsMenuRequest;
            _mainMenuCanvas.OnQuoteMenuRequest += OnQuoteMenuRequest;

            Debug.Log("MainMenuState OnEnter");
        }


        private void OnCreditsMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToCredits);
        }

        private void OnCoPilotMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToCoPilotRequest);
        }

        private void OnGarageMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToGarageRequest);
        }

        private void OnInventoryMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToInventoryRequest);
        }

        private void OnMarketMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToMarketRequest);
        }

        private void OnAchievementsMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToAchievementsRequest);
        }

        private void OnSettingsMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToSettingsRequest);
        }

        private void OnQuoteMenuRequest()
        {
            SendTrigger((int)StateTriggers.GoToQuoteRequest);
        }

        private void RequestInGameMenu()
        {
            SendTrigger((int)StateTriggers.StartGameRequest);
        }

        protected override void OnExit()
        {
            _mainMenuCanvas.OnInGameMenuRequest -= RequestInGameMenu;
            _mainMenuCanvas.OnSettingsMenuRequest -= OnSettingsMenuRequest;
            _mainMenuCanvas.OnAchievementsMenuRequest -= OnAchievementsMenuRequest;
            _mainMenuCanvas.OnMarketMenuRequest -= OnMarketMenuRequest;
            _mainMenuCanvas.OnInventoryMenuRequest -= OnInventoryMenuRequest;
            _mainMenuCanvas.OnCoPilotMenuRequest -= OnCoPilotMenuRequest;
            _mainMenuCanvas.OnCreditsMenuRequest -= OnCreditsMenuRequest;
            _mainMenuCanvas.OnQuoteMenuRequest -= OnQuoteMenuRequest;

            Debug.Log("MainMenuState OnExit");
        }

        protected override void OnUpdate()
        {
        }
    }
}