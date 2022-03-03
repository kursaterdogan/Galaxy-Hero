using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
    public class GameState : StateMachine
    {
        private PrepareGameState _prepareGameState;
        private InGameState _inGameState;
        private EndGameState _endGameState;

        private UIComponent _uiComponent;
        private InGameCanvas _inGameCanvas;

        public GameState(ComponentContainer componentContainer)
        {
            //TODO Hande GameState
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _inGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.InGame) as InGameCanvas;

            _prepareGameState = new PrepareGameState(componentContainer);
            _inGameState = new InGameState(componentContainer);
            _endGameState = new EndGameState(componentContainer);

            AddSubState(_prepareGameState);
            AddSubState(_inGameState);
            AddSubState(_endGameState);

            AddTransition(_prepareGameState, _inGameState, (int)StateTriggers.PlayGame);
            AddTransition(_inGameState, _endGameState, (int)StateTriggers.GameOver);
            AddTransition(_endGameState, _prepareGameState, (int)StateTriggers.ReplayGame);
        }

        protected override void OnEnter()
        {
            //TODO Create PrepareGameStateCanvas
            //TODO Move To IngGameState
            _uiComponent.EnableCanvas(UIComponent.MenuName.InGame);

            SubscribeToInGameCanvasRequestDelegates();
        }

        protected override void OnExit()
        {
            //TODO Move to InGameState
            UnsubscribeToInGameCanvasRequestDelegates();
        }

        private void SubscribeToInGameCanvasRequestDelegates()
        {
            _inGameCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        private void UnsubscribeToInGameCanvasRequestDelegates()
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