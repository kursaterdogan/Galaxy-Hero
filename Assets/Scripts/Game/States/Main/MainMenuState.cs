using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class MainMenuState : StateMachine, IChangeable, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly MainMenuComponent _mainMenuComponent;

        private readonly MainMenuCanvas _mainMenuCanvas;

        public MainMenuState(ComponentContainer componentContainer)
        {
            //TODO Handle Start Game
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _mainMenuComponent = componentContainer.GetComponent("MainMenuComponent") as MainMenuComponent;

            _mainMenuCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.MainMenu) as MainMenuCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _mainMenuComponent.OnConstruct();

            _uiComponent.EnableCanvas(UIComponent.MenuName.MainMenu);
        }

        protected override void OnExit()
        {
            _mainMenuComponent.OnDestruct();
            _mainMenuCanvas.OnQuit();

            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _mainMenuComponent.OnLeftSelectionButtonInteractableChange += ChangeLeftSelectionButtonInteractable;
            _mainMenuComponent.OnRightSelectionButtonInteractableChange += ChangeRightSelectionButtonInteractable;
            _mainMenuComponent.OnActivateSaturn += ActivateSaturn;
            _mainMenuComponent.OnActivateMars += ActivateMars;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _mainMenuComponent.OnLeftSelectionButtonInteractableChange -= ChangeLeftSelectionButtonInteractable;
            _mainMenuComponent.OnRightSelectionButtonInteractableChange -= ChangeRightSelectionButtonInteractable;
            _mainMenuComponent.OnActivateSaturn -= ActivateSaturn;
            _mainMenuComponent.OnActivateMars -= ActivateMars;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnLeftSelectionRequest += RequestLeftSelection;
            _mainMenuCanvas.OnRightSelectionRequest += RequestRightSelection;
            _mainMenuCanvas.OnInventoryRequest += RequestInventory;
            _mainMenuCanvas.OnGarageRequest += RequestGarage;
            _mainMenuCanvas.OnSuperPowerRequest += RequestSuperPower;
            _mainMenuCanvas.OnCreditsRequest += RequestCredits;
            _mainMenuCanvas.OnAchievementRequest += RequestAchievement;
            _mainMenuCanvas.OnStartGameRequest += RequestStartGame;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _mainMenuCanvas.OnLeftSelectionRequest -= RequestLeftSelection;
            _mainMenuCanvas.OnRightSelectionRequest -= RequestRightSelection;
            _mainMenuCanvas.OnInventoryRequest -= RequestInventory;
            _mainMenuCanvas.OnGarageRequest -= RequestGarage;
            _mainMenuCanvas.OnSuperPowerRequest -= RequestSuperPower;
            _mainMenuCanvas.OnCreditsRequest -= RequestCredits;
            _mainMenuCanvas.OnAchievementRequest -= RequestAchievement;
            _mainMenuCanvas.OnStartGameRequest -= RequestStartGame;
        }

        #region Changes

        private void ChangeLeftSelectionButtonInteractable(bool isInteractable)
        {
            _mainMenuCanvas.SetLeftSelectionButtonInteractable(isInteractable);
        }

        private void ChangeRightSelectionButtonInteractable(bool isInteractable)
        {
            _mainMenuCanvas.SetRightSelectionButtonInteractable(isInteractable);
        }

        private void ActivateSaturn()
        {
            _mainMenuCanvas.ActivateSaturn();
        }

        private void ActivateMars()
        {
            _mainMenuCanvas.ActivateMars();
        }

        #endregion

        #region Requests

        private void RequestLeftSelection()
        {
            _mainMenuComponent.RequestLeftSelectionButton();
        }

        private void RequestRightSelection()
        {
            _mainMenuComponent.RequestRightSelectionButton();
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

        private void RequestAchievement()
        {
            SendTrigger((int)StateTriggers.GoToAchievement);
        }

        private void RequestStartGame()
        {
            SendTrigger((int)StateTriggers.StartGame);
        }

        #endregion
    }
}