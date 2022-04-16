using Base.Component;
using Base.State;
using Game.Enums;
using Game.States.InGame;
using Game.States.Main;
using Game.States.Splash;

namespace Game.States
{
    public class AppState : StateMachine
    {
        private readonly SplashState _splashState;
        private readonly MainState _mainState;
        private readonly GameState _gameState;

        public AppState(ComponentContainer componentContainer)
        {
            _splashState = new SplashState(componentContainer);
            _mainState = new MainState(componentContainer);
            _gameState = new GameState(componentContainer);

            AddSubState(_splashState);
            AddSubState(_mainState);
            AddSubState(_gameState);

            AddTransition(_splashState, _mainState, (int)StateTrigger.GoToMainMenu);
            AddTransition(_mainState, _gameState, (int)StateTrigger.StartGame);
            AddTransition(_gameState, _mainState, (int)StateTrigger.ReturnToMainMenu);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }
    }
}