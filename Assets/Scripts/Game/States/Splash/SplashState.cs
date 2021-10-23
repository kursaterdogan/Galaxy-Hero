namespace Game.States.Splash
{
    using Base.Component;
    using Base.State;
    using UnityEngine;
    using States;

    public class SplashState : StateMachine
    {
        private LoadingState _loadingState;
        private IntroState _introState;

        public SplashState(ComponentContainer componentContainer)
        {
            _introState = new IntroState(componentContainer);
            _loadingState = new LoadingState();

            AddSubState(_introState);
            AddSubState(_loadingState);

            AddTransition(_introState, _loadingState, (int)StateTriggers.SplashLoading);
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