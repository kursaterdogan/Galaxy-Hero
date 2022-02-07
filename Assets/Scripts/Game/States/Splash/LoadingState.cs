using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Splash;

namespace Game.States.Splash
{
    public class LoadingState : StateMachine
    {
        private UIComponent _uiComponent;

        private SplashCanvas _splashCanvas;

        public LoadingState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;

            _splashCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Splash) as SplashCanvas;
        }

        protected override void OnEnter()
        {
            Debug.Log("LoadingState OnEnter");

            _splashCanvas.OnLoadingAnimationRequest += OnLoadingAnimationRequest;
        }

        protected override void OnUpdate()
        {
            Debug.Log("LoadingState OnUpdate");
        }

        protected override void OnExit()
        {
            Debug.Log("LoadingState OnExit");

            _splashCanvas.OnLoadingAnimationRequest += OnLoadingAnimationRequest;
        }

        private void OnLoadingAnimationRequest()
        {
            SendTrigger((int)StateTriggers.SplashCompleted);
        }
    }
}