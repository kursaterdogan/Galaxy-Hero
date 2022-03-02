using Base.State;
using Base.Component;
using Game.Components;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
    public class InGameState : StateMachine
    {
        private UIComponent _uiComponent;
        private GameplayComponent _gameplayComponent;
        private InGameCanvas _inGameCanvas;
        
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
            _gameplayComponent.OnConstruct();
        }

        protected override void OnExit()
        {
            _gameplayComponent.OnDestruct();
        }
    }
}