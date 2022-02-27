using UnityEngine;
using Base.Component;
using Base.State;

namespace Game.States.Splash
{
    public class SplashState : StateMachine
    {
        private LoadingState _loadingState;
        private IntroState _introState;

        public SplashState(ComponentContainer componentContainer)
        {
            _introState = new IntroState(componentContainer);
            _loadingState = new LoadingState(componentContainer);

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
    }
}