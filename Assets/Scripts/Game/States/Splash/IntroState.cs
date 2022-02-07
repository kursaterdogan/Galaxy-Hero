using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Splash;

namespace Game.States.Splash
{
    public class IntroState : StateMachine
    {
        private UIComponent _uiComponent;
        private IntroComponent _introComponent;
        
        private SplashCanvas _splashCanvas;

        public IntroState(ComponentContainer componentContainer)
        {
            _introComponent = componentContainer.GetComponent("IntroComponent") as IntroComponent;
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;

            _splashCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Splash) as SplashCanvas;
        }

        protected override void OnEnter()
        {
            Debug.Log("IntroState OnEnter");

            _splashCanvas.OnIntroAnimationRequest += OnIntroAnimationRequest;

            _introComponent.CallStart();
        }

        protected override void OnUpdate()
        {
            Debug.Log("IntroState OnUpdate");
        }

        protected override void OnExit()
        {
            Debug.Log("IntroState OnExit");

            _splashCanvas.OnIntroAnimationRequest -= OnIntroAnimationRequest;
        }

        private void OnIntroAnimationRequest()
        {
            SendTrigger((int)StateTriggers.SplashLoading);
        }
    }
}