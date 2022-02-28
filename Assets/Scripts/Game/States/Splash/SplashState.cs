using UnityEngine;
using Base.Component;
using Base.State;

namespace Game.States.Splash
{
    public class SplashState : StateMachine
    {
        private IntroState _introState;

        public SplashState(ComponentContainer componentContainer)
        {
            _introState = new IntroState(componentContainer);

            AddSubState(_introState);
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