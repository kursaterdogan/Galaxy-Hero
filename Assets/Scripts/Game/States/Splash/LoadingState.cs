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
        private SplashComponent _splashComponent;

        private SplashCanvas _splashCanvas;

        public LoadingState(ComponentContainer componentContainer)
        {
            _splashComponent = componentContainer.GetComponent("SplashComponent") as SplashComponent;
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;

            _splashCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Splash) as SplashCanvas;
        }

        protected override void OnEnter()
        {
            Debug.Log("LoadingState OnEnter");

            _uiComponent.EnableCanvas(UIComponent.MenuName.Splash);

            _splashComponent.OnLogoAnimationStart += StartLogoAnimation;
            _splashComponent.OnLogoAnimationComplete += CompleteLogoAnimation;
            _splashComponent.OnLoadingIconAnimationStart += StartLoadingIconAnimation;
            _splashComponent.OnLoadingIconAnimationComplete += CompleteLoadingIconAnimation;
            _splashComponent.OnSplashComplete += CompleteSplashAnimation;
            _splashComponent.OnSplashComplete += CompleteSplash;

            _splashComponent.CallStart();
        }

        protected override void OnExit()
        {
            _splashComponent.OnLogoAnimationStart -= StartLogoAnimation;
            _splashComponent.OnLogoAnimationComplete -= CompleteLogoAnimation;
            _splashComponent.OnLoadingIconAnimationStart -= StartLoadingIconAnimation;
            _splashComponent.OnLoadingIconAnimationComplete -= CompleteLoadingIconAnimation;
            _splashComponent.OnSplashComplete -= CompleteSplashAnimation;
            _splashComponent.OnSplashComplete -= CompleteSplash;

            Debug.Log("LoadingState OnExit");
        }

        private void StartLogoAnimation()
        {
            _splashCanvas.PlayLogoFadeInAnimation(_splashComponent.GetAnimationTime());
        }

        private void CompleteLogoAnimation()
        {
            _splashCanvas.PlayLogoFadeOutAnimation(_splashComponent.GetAnimationTime());
        }

        private void StartLoadingIconAnimation()
        {
            _splashCanvas.PlayLoadingIconAnimation();
        }

        private void CompleteLoadingIconAnimation()
        {
            _splashCanvas.StopLoadingIconAnimation();
        }

        private void CompleteSplashAnimation()
        {
            _splashCanvas.DisableObjects();
        }

        private void CompleteSplash()
        {
            SendTrigger((int)StateTriggers.SplashCompleted);
        }
    }
}