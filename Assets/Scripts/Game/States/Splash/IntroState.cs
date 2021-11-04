namespace Game.States.Splash
{
    using Components;
    using Base.Component;
    using Base.State;
    using UnityEngine;

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

        protected override void OnExit()
        {
            Debug.Log("IntroState OnExit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("IntroState OnUpdate");

            if (_introComponent.IsIntroAnimationCompleted())
            {
                SendTrigger((int)StateTriggers.SplashLoading);
            }
        }
    }
}