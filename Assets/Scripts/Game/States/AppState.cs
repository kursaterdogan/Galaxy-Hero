namespace Game.States
{
    using UnityEngine;
    using Base.State;
    using Base.Component;
    using Splash;
    using Main;

    public class AppState : StateMachine
    {
        private SplashState _splashState;
        private MainState _mainState;

        public AppState(ComponentContainer componentContainer)
        {
            _splashState = new SplashState(componentContainer);
            _mainState = new MainState(componentContainer);

            AddSubState(_splashState);
            AddSubState(_mainState);

            AddTransition(_splashState, _mainState, (int)StateTriggers.SplashCompleted);
        }

        protected override void OnEnter()
        {
            Debug.Log("AppState OnEnter");
        }

        protected override void OnUpdate()
        {
            Debug.Log("AppState Update");
        }

        protected override void OnExit()
        {
            Debug.Log("AppState OnExit");
        }
    }
}