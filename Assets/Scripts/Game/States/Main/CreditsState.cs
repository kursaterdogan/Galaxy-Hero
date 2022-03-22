using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class CreditsState : StateMachine, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly CreditsComponent _creditsComponent;

        private readonly CreditsCanvas _creditsCanvas;

        public CreditsState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _creditsComponent = componentContainer.GetComponent("CreditsComponent") as CreditsComponent;
            
            _creditsCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Credits) as CreditsCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToCanvasRequestDelegates();
            
            _uiComponent.EnableCanvas(UIComponent.MenuName.Credits);
        }

        protected override void OnExit()
        {
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _creditsCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _creditsCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }
        
        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}