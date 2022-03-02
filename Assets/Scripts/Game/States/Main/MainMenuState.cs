using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.MainMenu;

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
            Debug.Log("MainMenuState OnEnter");

            SubscribeToCanvasRequestDelegates();

            _uiComponent.EnableCanvas(UIComponent.MenuName.MainMenu);
        }

        protected override void OnExit()
        {
            UnsubscribeToCanvasRequestDelegates();

            Debug.Log("MainMenuState OnExit");
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnInGameMenuRequest += RequestStartGame;
            _mainMenuCanvas.OnInventoryMenuRequest += RequestInventory;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnInGameMenuRequest -= RequestStartGame;
            _mainMenuCanvas.OnInventoryMenuRequest -= RequestInventory;
        }

        private void RequestCredits()
        {
            SendTrigger((int)StateTriggers.GoToCredits);
        }

        private void RequestCoPilot()
        {
            //TODO Delete & Rename Unused Triggers 
            SendTrigger((int)StateTriggers.GoToCoPilot);
        }

        private void RequestInventory()
        {
            SendTrigger((int)StateTriggers.GoToInventory);
        }

        private void RequestAchievements()
        {
            SendTrigger((int)StateTriggers.GoToAchievements);
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