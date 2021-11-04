namespace Game.States.Splash
{
    using Base.Component;
    using Base.State;
    using UnityEngine;
    using States;
    using Components;

    public class SplashState : StateMachine
    {
        private LoadingState _loadingState;
        private IntroState _introState;
        private UIComponent _uiComponent;

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
            Debug.Log("SplashState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("Splash State OnExit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("SplashState OnUpdate");
        }
    }
}