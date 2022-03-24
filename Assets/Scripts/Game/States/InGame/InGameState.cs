using Base.State;
using Base.Component;
using Game.Components;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
    public class InGameState : StateMachine, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly GameplayComponent _gameplayComponent;
        private readonly InGameCanvas _inGameCanvas;

        public InGameState(ComponentContainer componentContainer)
        {
            //TODO Hande InGameState
            _gameplayComponent = componentContainer.GetComponent("GameplayComponent") as GameplayComponent;

            //TODO Handle Canvas Delegates
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _inGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.InGame) as InGameCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToCanvasRequestDelegates();

            _gameplayComponent.OnConstruct();

            _uiComponent.EnableCanvas(UIComponent.MenuName.InGame);
        }

        protected override void OnExit()
        {
            _gameplayComponent.OnDestruct();

            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _inGameCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _inGameCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        private void RequestReturnToMainMenu()
        {
            //TODO Add Pause, Restart, GameOver
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}