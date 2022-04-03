using Base.Component;
using Base.State;
using Game.Components;
using Game.Enums;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class SuperPowerState : StateMachine, IChangeable, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly SuperPowerComponent _superPowerComponent;

        private readonly SuperPowerCanvas _superPowerCanvas;

        public SuperPowerState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _superPowerComponent = componentContainer.GetComponent("SuperPowerComponent") as SuperPowerComponent;

            _superPowerCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.SuperPower) as SuperPowerCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _superPowerComponent.OnConstruct();

            _uiComponent.EnableCanvas(UIComponent.MenuName.SuperPower);
        }

        protected override void OnExit()
        {
            _superPowerComponent.OnDestruct();
            _superPowerCanvas.OnQuit();

            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _superPowerComponent.OnShildeoDescriptionChange += ChangeShildeoDescriptionText;
            _superPowerComponent.OnBombeoDescriptionChange += ChangeBombeoDescriptionText;
            _superPowerComponent.OnGhosteoDescriptionChange += ChangeGhosteoDescriptionText;
            _superPowerComponent.OnLeftSelectionButtonInteractableChange += ChangeLeftSelectionButtonInteractable;
            _superPowerComponent.OnRightSelectionButtonInteractableChange += ChangeRightSelectionButtonInteractable;
            _superPowerComponent.OnActivateShildeo += ActivateShildeo;
            _superPowerComponent.OnActivateBombeo += ActivateBombeo;
            _superPowerComponent.OnActivateGhosteo += ActivateGhosteo;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _superPowerComponent.OnShildeoDescriptionChange -= ChangeShildeoDescriptionText;
            _superPowerComponent.OnBombeoDescriptionChange -= ChangeBombeoDescriptionText;
            _superPowerComponent.OnGhosteoDescriptionChange -= ChangeGhosteoDescriptionText;
            _superPowerComponent.OnLeftSelectionButtonInteractableChange -= ChangeLeftSelectionButtonInteractable;
            _superPowerComponent.OnRightSelectionButtonInteractableChange -= ChangeRightSelectionButtonInteractable;
            _superPowerComponent.OnActivateShildeo -= ActivateShildeo;
            _superPowerComponent.OnActivateBombeo -= ActivateBombeo;
            _superPowerComponent.OnActivateGhosteo -= ActivateGhosteo;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _superPowerCanvas.OnLeftSelectionRequest += RequestLeftSelection;
            _superPowerCanvas.OnRightSelectionRequest += RequestRightSelection;
            _superPowerCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _superPowerCanvas.OnLeftSelectionRequest -= RequestLeftSelection;
            _superPowerCanvas.OnRightSelectionRequest -= RequestRightSelection;
            _superPowerCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        #region Changes

        private void ChangeShildeoDescriptionText(string description)
        {
            _superPowerCanvas.SetShildeoDescriptionText(description);
        }

        private void ChangeBombeoDescriptionText(string description)
        {
            _superPowerCanvas.SetBombeoDescriptionText(description);
        }

        private void ChangeGhosteoDescriptionText(string description)
        {
            _superPowerCanvas.SetGhosteoDescriptionText(description);
        }

        private void ChangeLeftSelectionButtonInteractable(bool isInteractable)
        {
            _superPowerCanvas.SetLeftSelectionButtonInteractable(isInteractable);
        }

        private void ChangeRightSelectionButtonInteractable(bool isInteractable)
        {
            _superPowerCanvas.SetRightSelectionButtonInteractable(isInteractable);
        }

        private void ActivateShildeo()
        {
            _superPowerCanvas.ActivateShildeo();
        }

        private void ActivateBombeo()
        {
            _superPowerCanvas.ActivateBombeo();
        }

        private void ActivateGhosteo()
        {
            _superPowerCanvas.ActivateGhosteo();
        }

        #endregion

        #region Request

        private void RequestLeftSelection()
        {
            _superPowerComponent.RequestLeftSelectionButton();
        }

        private void RequestRightSelection()
        {
            _superPowerComponent.RequestRightSelectionButton();
        }

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTrigger.ReturnToMainMenu);
        }

        #endregion
    }
}