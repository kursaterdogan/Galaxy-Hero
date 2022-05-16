using Base.Component;
using Base.State;
using Game.Components;
using Game.Enums;
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

            _introCanvas = _uiComponent.GetCanvas(CanvasTrigger.Intro) as IntroCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();

            _introCanvas.OnStart();

            _introComponent.OnConstruct();

            _uiComponent.EnableCanvas(CanvasTrigger.Intro);
        }

        protected override void OnExit()
        {
            _introCanvas.OnQuit();

            UnsubscribeToComponentChangeDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _introComponent.OnIntroAnimationStart += StartIntroAnimation;
            _introComponent.OnIntroAnimationComplete += RequestMain;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _introComponent.OnIntroAnimationStart -= StartIntroAnimation;
            _introComponent.OnIntroAnimationComplete -= RequestMain;
        }

        private void StartIntroAnimation(float time)
        {
            _introCanvas.PlayLogoFadeOutAnimation(time);
        }

        private void RequestMain()
        {
            SendTrigger((int)StateTrigger.GoToMain);
        }
    }
}