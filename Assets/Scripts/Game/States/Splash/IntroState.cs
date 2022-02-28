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

        private IntroCanvas _introCanvas;

        public IntroState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _introComponent = componentContainer.GetComponent("IntroComponent") as IntroComponent;

            _introCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Intro) as IntroCanvas;
        }

        protected override void OnEnter()
        {
            Debug.Log("LoadingState OnEnter");

            _uiComponent.EnableCanvas(UIComponent.MenuName.Intro);

            _introComponent.OnIntroAnimationStart += StartIntroAnimation;
            _introComponent.OnIntroAnimationComplete += CompleteIntroAnimation;
            _introComponent.OnIntroAnimationComplete += RequestMainMenu;

            _introCanvas.OnStart();
            _introComponent.OnConstruct();
        }

        protected override void OnExit()
        {
            _introComponent.OnIntroAnimationStart -= StartIntroAnimation;
            _introComponent.OnIntroAnimationComplete -= CompleteIntroAnimation;
            _introComponent.OnIntroAnimationComplete -= RequestMainMenu;

            _introCanvas.OnQuit();

            Debug.Log("LoadingState OnExit");
        }

        private void StartIntroAnimation()
        {
            _introCanvas.PlayLoadingIconAnimation();
            _introCanvas.PlayLogoFadeOutAnimation(_introComponent.GetAnimationTime());
        }

        private void CompleteIntroAnimation()
        {
            _introCanvas.StopLoadingIconAnimation();
        }

        private void RequestMainMenu()
        {
            SendTrigger((int)StateTriggers.GoToMainMenu);
        }
    }
}