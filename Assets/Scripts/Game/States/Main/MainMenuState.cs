using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.MainMenu;

namespace Game.States.Main
{
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
            Debug.Log("MainMenuState OnEnter");

            //TODO Check MainMenuCanvas
            _uiComponent.EnableCanvas(UIComponent.MenuName.MainMenu);

            SubscribeToMainMenuRequestDelegates();
        }

        protected override void OnExit()
        {
            UnsubscribeToMainMenuRequestDelegates();

            Debug.Log("MainMenuState OnExit");
        }

        private void SubscribeToMainMenuRequestDelegates()
        {
            _mainMenuCanvas.OnInGameMenuRequest += RequestStartGame;
            _mainMenuCanvas.OnSettingsMenuRequest += RequestSettingsMenu;
            _mainMenuCanvas.OnAchievementsMenuRequest += RequestAchievementsMenu;
            _mainMenuCanvas.OnGarageMenuRequest += RequestGarageMenu;
            _mainMenuCanvas.OnCoPilotMenuRequest += RequestCoPilotMenu;
            _mainMenuCanvas.OnCreditsMenuRequest += RequestCreditsMenu;
            _mainMenuCanvas.OnQuoteMenuRequest += RequestQuoteMenu;
        }

        private void UnsubscribeToMainMenuRequestDelegates()
        {
            _mainMenuCanvas.OnInGameMenuRequest -= RequestStartGame;
            _mainMenuCanvas.OnSettingsMenuRequest -= RequestSettingsMenu;
            _mainMenuCanvas.OnAchievementsMenuRequest -= RequestAchievementsMenu;
            _mainMenuCanvas.OnGarageMenuRequest -= RequestGarageMenu;
            _mainMenuCanvas.OnCoPilotMenuRequest -= RequestCoPilotMenu;
            _mainMenuCanvas.OnCreditsMenuRequest -= RequestCreditsMenu;
            _mainMenuCanvas.OnQuoteMenuRequest -= RequestQuoteMenu;
        }

        private void RequestCreditsMenu()
        {
            SendTrigger((int)StateTriggers.GoToCredits);
        }

        private void RequestCoPilotMenu()
        {
            //TODO Delete & Rename Unused Triggers 
            SendTrigger((int)StateTriggers.GoToCoPilot);
        }

        private void RequestGarageMenu()
        {
            SendTrigger((int)StateTriggers.GoToGarage);
        }

        private void RequestAchievementsMenu()
        {
            SendTrigger((int)StateTriggers.GoToAchievements);
        }

        private void RequestSettingsMenu()
        {
            SendTrigger((int)StateTriggers.GoToSettings);
        }

        private void RequestQuoteMenu()
        {
            SendTrigger((int)StateTriggers.GoToQuote);
        }

        private void RequestStartGame()
        {
            SendTrigger((int)StateTriggers.StartGame);
        }
    }
}