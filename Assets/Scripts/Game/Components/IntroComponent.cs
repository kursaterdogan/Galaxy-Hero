using Base.Component;
using Game.UserInterfaces.Splash;
using UnityEngine;

namespace Game.Components
{
    public class IntroComponent : MonoBehaviour, IComponent, IStartable
    {
        private UIComponent _uiComponent;
        private SplashCanvas _splashCanvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>IntroComponent initialized!</color>");

            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            
            _splashCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Splash) as SplashCanvas;
        }

        public void CallStart()
        {
            StartIntro();
        }

        private void StartIntro()
        {
            _splashCanvas.PlayIntroAnimation();
        }
    }
}