using UnityEngine;
using Base.Component;
using Base.State;

namespace Game.States.Splash
{
    public class SplashState : StateMachine
    {
        private LoadingState _loadingState;

        public SplashState(ComponentContainer componentContainer)
        {
            _loadingState = new LoadingState(componentContainer);

            AddSubState(_loadingState);
        }

        protected override void OnEnter()
        {
            Debug.Log("SplashState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("SplashState OnExit");
        }
    }
}