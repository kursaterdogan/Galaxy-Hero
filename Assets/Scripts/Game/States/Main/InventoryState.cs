using UnityEngine;
using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class InventoryState : StateMachine, IRequestable
    {
        private UIComponent _uiComponent;
        private InventoryComponent _inventoryComponent;

        private InventoryCanvas _inventoryCanvas;

        public InventoryState(ComponentContainer componentContainer)
        {
            //TODO Handle Inventory
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _inventoryComponent = componentContainer.GetComponent("InventoryComponent") as InventoryComponent;

            _inventoryCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Inventory) as InventoryCanvas;
        }

        protected override void OnEnter()
        {
            Debug.Log("InventoryState OnEnter");

            SubscribeToCanvasRequestDelegates();

            _uiComponent.EnableCanvas(UIComponent.MenuName.Inventory);
        }

        protected override void OnExit()
        {
            UnsubscribeToCanvasRequestDelegates();

            Debug.Log("InventoryState OnExit");
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _inventoryCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _inventoryCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}