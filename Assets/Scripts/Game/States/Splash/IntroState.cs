namespace Game.States.Splash
{
    using Base.Component;
    using Base.State;
    using UnityEngine;

    public class IntroState : StateMachine
    {
        //TODO Create _introComponent
        // private IntroComponent _introComponent;

        public IntroState(ComponentContainer componentContainer)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("Intro state On Enter");
        }

        protected override void OnExit()
        {
            Debug.Log("Intro state On Exit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("Intro state On Update");
        }
    }
}