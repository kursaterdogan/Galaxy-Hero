namespace Game.States.Splash
{
    using Base.Component;
    using Base.State;
    using UnityEngine;
    using Game.States;

    public class SplashState : StateMachine
    {
        private LoadingState _loadingState;
        private IntroState _introState;

        public SplashState(ComponentContainer componentContainer) 
        {
            _loadingState = new LoadingState();
            _introState = new IntroState(componentContainer);

            AddSubState(_introState);
            AddSubState(_loadingState);

            AddTransition(_introState, _loadingState, (int)StateTriggers.SPLASH_LOADING);
        }

        protected override void OnEnter()
        {
            Debug.Log("Splash State On Enter");
        }

        protected override void OnExit()
        {
            Debug.Log("Splash State On Exit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("Splash State On Update");
        }
    }
}