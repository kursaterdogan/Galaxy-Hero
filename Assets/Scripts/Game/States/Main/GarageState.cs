using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class GarageState : StateMachine, IRequestable
    {
        private UIComponent _uiComponent;
        private GarageComponent _garageComponent;

        private GarageCanvas _garageCanvas;

        public GarageState(ComponentContainer componentContainer)
        {
            //TODO Initialize GarageCanvas
            //TODO Add Components
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _garageComponent = componentContainer.GetComponent("GarageComponent") as GarageComponent;

            _garageCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Garage) as GarageCanvas;
        }

        protected override void OnEnter()
        {
            //TODO Handle OnEnter
            Debug.Log("<color=orange>GarageState OnEnter</color>");

            SubscribeToCanvasRequestDelegates();

            _uiComponent.EnableCanvas(UIComponent.MenuName.Garage);
        }

        protected override void OnExit()
        {
            //TODO Handle OnExit
            UnsubscribeToCanvasRequestDelegates();

            Debug.Log("<color=cyan>GarageState OnExit</color>");
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _garageCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _garageCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        private void RequestReturnToMainMenu()
        {
            //TODO Subscribe & Unsubscribe
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}