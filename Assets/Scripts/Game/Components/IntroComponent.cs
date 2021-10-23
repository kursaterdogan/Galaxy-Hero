namespace Game.Components
{
    using Base.Component;
    using UserInterfaces.Splash;
    using UnityEngine;

    public class IntroComponent : MonoBehaviour, IComponent
    {
        private UIComponent _uiComponent;
        private SplashCanvas _splashCanvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _splashCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Splash) as SplashCanvas;
        }

        public bool IsIntroAnimationCompleted()
        {
            return _splashCanvas.IsIntroCompleted();
        }

        public void StartIntro()
        {
            _uiComponent.EnableCanvas(UIComponent.MenuName.Splash);
            _splashCanvas.PlayIntroAnimation();
        }
    }
}