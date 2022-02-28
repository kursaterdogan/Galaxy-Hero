using UnityEngine;
using Base.Component;
using Base.State;
using Game.States.InGame;
using Game.States.Main;
using Game.States.Splash;

namespace Game.States
{
    public class AppState : StateMachine
    {
        private SplashState _splashState;
        private MainState _mainState;
        private GameState _gameState;

        public AppState(ComponentContainer componentContainer)
        {
            _splashState = new SplashState(componentContainer);
            _mainState = new MainState(componentContainer);
            _gameState = new GameState(componentContainer);

            AddSubState(_splashState);
            AddSubState(_mainState);
            AddSubState(_gameState);

            AddTransition(_splashState, _mainState, (int)StateTriggers.GoToMainMenu);
            AddTransition(_mainState, _gameState, (int)StateTriggers.StartGame);
            //TODO Handle EndGameState
            AddTransition(_gameState, _mainState, (int)StateTriggers.ReturnToMainMenu);
        }

        protected override void OnEnter()
        {
            Debug.Log("AppState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("AppState OnExit");
        }
    }
}