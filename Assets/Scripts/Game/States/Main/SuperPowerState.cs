using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class SuperPowerState : StateMachine, IRequestable
    {
        private UIComponent _uiComponent;
        private SuperPowerComponent _superPowerComponent;

        private SuperPowerCanvas _superPowerCanvas;

        public SuperPowerState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _superPowerComponent = componentContainer.GetComponent("SuperPowerComponent") as SuperPowerComponent;

            _superPowerCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.SuperPower) as SuperPowerCanvas;
        }

        protected override void OnEnter()
        {
            _uiComponent.EnableCanvas(UIComponent.MenuName.SuperPower);

            SubscribeToCanvasRequestDelegates();
        }

        protected override void OnExit()
        {
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _superPowerCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _superPowerCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}