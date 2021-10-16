namespace Game.States
{
    using UnityEngine;
    using Base.State;
    using Base.Component;
    using Splash;

    public class AppState : StateMachine
    {
        private SplashState _splashState;

        public AppState(ComponentContainer componentContainer)
        {
            _splashState = new SplashState(componentContainer);
            AddSubState(_splashState);
            _splashState.Enter();
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