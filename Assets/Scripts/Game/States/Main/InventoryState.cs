using Base.Component;
using Base.State;
using Game.Components;
using Game.Enums;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class InventoryState : StateMachine, IRequestable, IChangeable
    {
        private readonly UIComponent _uiComponent;
        private readonly InventoryComponent _inventoryComponent;

        private readonly InventoryCanvas _inventoryCanvas;

        public InventoryState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _inventoryComponent = componentContainer.GetComponent("InventoryComponent") as InventoryComponent;

            _inventoryCanvas = _uiComponent.GetCanvas(CanvasTrigger.Inventory) as InventoryCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _inventoryComponent.OnConstruct();

            _uiComponent.EnableCanvas(CanvasTrigger.Inventory);
        }

        protected override void OnExit()
        {
            _inventoryComponent.OnDestruct();

            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _inventoryComponent.OnSaturnCardOpenStart += StartSaturnCardOpen;
            _inventoryComponent.OnSaturnCardShakeStart += StartSaturnCardShake;
            _inventoryComponent.OnSaturnCardOpenEnd += EndSaturnCardOpen;
            _inventoryComponent.OnSaturnCardShakeEnd += EndSaturnCardShake;
            _inventoryComponent.OnMarsCardOpenStart += StartMarsCardOpen;
            _inventoryComponent.OnMarsCardShakeStart += StartMarsCardShake;
            _inventoryComponent.OnMarsCardOpenEnd += EndMarsCardOpen;
            _inventoryComponent.OnMarsCardShakeEnd += EndMarsCardShake;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _inventoryComponent.OnSaturnCardOpenStart -= StartSaturnCardOpen;
            _inventoryComponent.OnSaturnCardShakeStart -= StartSaturnCardShake;
            _inventoryComponent.OnSaturnCardOpenEnd -= EndSaturnCardOpen;
            _inventoryComponent.OnSaturnCardShakeEnd -= EndSaturnCardShake;
            _inventoryComponent.OnMarsCardOpenStart -= StartMarsCardOpen;
            _inventoryComponent.OnMarsCardShakeStart -= StartMarsCardShake;
            _inventoryComponent.OnMarsCardOpenEnd -= EndMarsCardOpen;
            _inventoryComponent.OnMarsCardShakeEnd -= EndMarsCardShake;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _inventoryCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _inventoryCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        #region Changes

        private void StartSaturnCardOpen()
        {
            _inventoryCanvas.StartSaturnCardOpen();
        }

        private void StartSaturnCardShake()
        {
            _inventoryCanvas.StartSaturnCardShake();
        }

        private void EndSaturnCardOpen()
        {
            _inventoryCanvas.EndSaturnCardOpen();
        }

        private void EndSaturnCardShake()
        {
            _inventoryCanvas.EndSaturnCardShake();
        }

        private void StartMarsCardOpen()
        {
            _inventoryCanvas.StartMarsCardOpen();
        }

        private void StartMarsCardShake()
        {
            _inventoryCanvas.StartMarsCardShake();
        }

        private void EndMarsCardOpen()
        {
            _inventoryCanvas.EndMarsCardOpen();
        }

        private void EndMarsCardShake()
        {
            _inventoryCanvas.EndMarsCardShake();
        }

        #endregion

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTrigger.ReturnToMainMenu);
        }
    }
}