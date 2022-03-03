using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class SettingsState : StateMachine, IRequestable
    {
        private UIComponent _uiComponent;
        private SettingsComponent _settingsComponent;

        private SettingsCanvas _settingsCanvas;

        public SettingsState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _settingsComponent = componentContainer.GetComponent("CreditsComponent") as SettingsComponent;

            _settingsCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Settings) as SettingsCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToCanvasRequestDelegates();

            _uiComponent.EnableCanvas(UIComponent.MenuName.Settings);
        }

        protected override void OnExit()
        {
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _settingsCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _settingsCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}