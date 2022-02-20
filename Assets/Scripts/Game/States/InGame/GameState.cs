using UnityEngine;
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
        private PauseGameState _pauseGameState;
        private EndGameState _endGameState;

        private UIComponent _uiComponent;
        private InGameCanvas _inGameCanvas;

        public GameState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _inGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.InGame) as InGameCanvas;

            _prepareGameState = new PrepareGameState(componentContainer);
            _inGameState = new InGameState(componentContainer);
            _pauseGameState = new PauseGameState(componentContainer);
            _endGameState = new EndGameState(componentContainer);

            AddSubState(_prepareGameState);
            AddSubState(_inGameState);
            AddSubState(_pauseGameState);
            AddSubState(_endGameState);

            AddTransition(_prepareGameState, _inGameState, (int)StateTriggers.PlayGameRequest);
            AddTransition(_inGameState, _pauseGameState, (int)StateTriggers.PauseGameRequest);
            AddTransition(_pauseGameState, _inGameState, (int)StateTriggers.ResumeGameRequest);
            AddTransition(_inGameState, _endGameState, (int)StateTriggers.GameOver);
            AddTransition(_endGameState, _prepareGameState, (int)StateTriggers.ReplayGameRequest);
        }

        protected override void OnEnter()
        {
            Debug.Log("GameState OnEnter");

            _uiComponent.EnableCanvas(UIComponent.MenuName.InGame);
            _inGameCanvas.OnReturnToMainMenu += ReturnToMainMenu;
        }

        protected override void OnExit()
        {
            Debug.Log("GameState OnExit");

            _inGameCanvas.OnReturnToMainMenu -= ReturnToMainMenu;
            SetDefaultState();
        }

        private void ReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.GoToMainMenuRequest);
        }
    }
}