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
            Debug.Log("Intro state On Enter");
            _introComponent.StartIntro();
        }

        protected override void OnExit()
        {
            Debug.Log("Intro state On Exit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("Intro state On Update");

            if (_introComponent.IsIntroAnimationCompleted())
            {
                SendTrigger((int)StateTriggers.SplashLoading);
            }
        }
    }
}