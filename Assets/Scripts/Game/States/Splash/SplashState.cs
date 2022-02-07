using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;

namespace Game.States.Splash
{
    public class SplashState : StateMachine
    {
        private LoadingState _loadingState;
        private IntroState _introState;
        private UIComponent _uiComponent;

        public SplashState(ComponentContainer componentContainer)
        {
            _introState = new IntroState(componentContainer);
            _loadingState = new LoadingState(componentContainer);

            AddSubState(_introState);
            AddSubState(_loadingState);

            AddTransition(_introState, _loadingState, (int)StateTriggers.SplashLoading);

            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
        }

        protected override void OnEnter()
        {
            Debug.Log("SplashState OnEnter");

            _uiComponent.EnableCanvas(UIComponent.MenuName.Splash);
        }

        protected override void OnUpdate()
        {
            Debug.Log("SplashState OnUpdate");
        }

        protected override void OnExit()
        {
            Debug.Log("Splash State OnExit");
        }
    }
}