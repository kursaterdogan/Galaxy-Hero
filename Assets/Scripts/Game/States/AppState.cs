namespace Game.States
{
    using UnityEngine;
    using Base.State;
    using Base.Component;
    using Splash;
    using Main;
    using InGame;

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

            AddTransition(_splashState, _mainState, (int)StateTriggers.SplashCompleted);
            AddTransition(_mainState, _gameState, (int)StateTriggers.StartGameRequest);
            AddTransition(_gameState, _mainState, (int)StateTriggers.GoToMainMenuRequest);
        }

        protected override void OnEnter()
        {
            Debug.Log("AppState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("AppState OnExit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("AppState Update");
        }
    }
}