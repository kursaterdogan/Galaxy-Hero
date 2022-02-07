using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;

namespace Game.States.Splash
{
    public class IntroState : StateMachine
    {
        private IntroComponent _introComponent;

        public IntroState(ComponentContainer componentContainer)
        {
            _introComponent = componentContainer.GetComponent("IntroComponent") as IntroComponent;
        }

        protected override void OnEnter()
        {
            Debug.Log("IntroState OnEnter");

            _introComponent.StartIntro();
        }

        protected override void OnUpdate()
        {
            Debug.Log("IntroState OnUpdate");

            if (_introComponent.IsIntroAnimationCompleted())
            {
                SendTrigger((int)StateTriggers.SplashLoading);
            }
        }

        protected override void OnExit()
        {
            Debug.Log("IntroState OnExit");
        }
    }
}