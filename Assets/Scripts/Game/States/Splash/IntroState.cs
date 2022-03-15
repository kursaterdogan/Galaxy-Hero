using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Splash;

namespace Game.States.Splash
{
    public class IntroState : StateMachine, IChangeable
    {
        private readonly UIComponent _uiComponent;
        private readonly IntroComponent _introComponent;

        private readonly IntroCanvas _introCanvas;

        public IntroState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _introComponent = componentContainer.GetComponent("IntroComponent") as IntroComponent;

            _introCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Intro) as IntroCanvas;
        }

        protected override void OnEnter()
        {
            _uiComponent.EnableCanvas(UIComponent.MenuName.Intro);

            SubscribeToComponentChangeDelegates();

            _introCanvas.OnStart();

            _introComponent.OnConstruct();
        }

        protected override void OnExit()
        {
            UnsubscribeToComponentChangeDelegates();

            _introCanvas.OnQuit();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _introComponent.OnIntroAnimationStart += StartIntroAnimation;
            _introComponent.OnIntroAnimationComplete += CompleteIntroAnimation;
            _introComponent.OnIntroAnimationComplete += RequestMainMenu;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _introComponent.OnIntroAnimationStart -= StartIntroAnimation;
            _introComponent.OnIntroAnimationComplete -= CompleteIntroAnimation;
            _introComponent.OnIntroAnimationComplete -= RequestMainMenu;
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