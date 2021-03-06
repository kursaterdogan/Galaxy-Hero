using Base.Component;
using Base.State;
using Game.Components;
using Game.Enums;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class GarageState : StateMachine, IChangeable, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly GarageComponent _garageComponent;

        private readonly GarageCanvas _garageCanvas;

        public GarageState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _garageComponent = componentContainer.GetComponent("GarageComponent") as GarageComponent;

            _garageCanvas = _uiComponent.GetCanvas(CanvasTrigger.Garage) as GarageCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _garageComponent.OnConstruct();

            _uiComponent.EnableCanvas(CanvasTrigger.Garage);
        }

        protected override void OnExit()
        {
            _garageComponent.OnDestruct();

            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _garageComponent.OnGoldAmountChange += ChangeGoldAmount;

            _garageComponent.OnHealthButtonInteractableChange += ChangeHealthButtonInteractable;
            _garageComponent.OnSpeedButtonInteractableChange += ChangeSpeedButtonInteractable;
            _garageComponent.OnCannonButtonInteractableChange += ChangeCannonButtonInteractable;
            _garageComponent.OnPowerButtonInteractableChange += ChangePowerButtonInteractable;
            _garageComponent.OnFireRateButtonInteractableChange += ChangeFireRateButtonInteractable;
            _garageComponent.OnScoreMultiplierButtonInteractableChange += ChangeScoreMultiplierButtonInteractable;
            _garageComponent.OnGoldMultiplierButtonInteractableChange += ChangeGoldMultiplierButtonInteractable;
            _garageComponent.OnShildeoButtonInteractableChange += ChangeShildeoButtonInteractable;
            _garageComponent.OnBombeoButtonInteractableChange += ChangeBombeoButtonInteractable;
            _garageComponent.OnGhosteoButtonInteractableChange += ChangeGhosteoButtonInteractable;

            _garageComponent.OnHealthUpgradeChange += ChangeHealthUpgrade;
            _garageComponent.OnSpeedUpgradeChange += ChangeSpeedUpgrade;
            _garageComponent.OnCannonUpgradeChange += ChangeCannonUpgrade;
            _garageComponent.OnPowerUpgradeChange += ChangePowerUpgrade;
            _garageComponent.OnFireRateUpgradeChange += ChangeFireRateUpgrade;
            _garageComponent.OnScoreMultiplierUpgradeChange += ChangeScoreMultiplierUpgrade;
            _garageComponent.OnGoldMultiplierUpgradeChange += ChangeGoldMultiplierUpgrade;
            _garageComponent.OnShildeoUpgradeChange += ChangeShildeoUpgrade;
            _garageComponent.OnBombeoUpgradeChange += ChangeBombeoUpgrade;
            _garageComponent.OnGhosteoUpgradeChange += ChangeGhosteoUpgrade;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _garageComponent.OnGoldAmountChange -= ChangeGoldAmount;

            _garageComponent.OnHealthButtonInteractableChange -= ChangeHealthButtonInteractable;
            _garageComponent.OnSpeedButtonInteractableChange -= ChangeSpeedButtonInteractable;
            _garageComponent.OnCannonButtonInteractableChange -= ChangeCannonButtonInteractable;
            _garageComponent.OnPowerButtonInteractableChange -= ChangePowerButtonInteractable;
            _garageComponent.OnFireRateButtonInteractableChange -= ChangeFireRateButtonInteractable;
            _garageComponent.OnScoreMultiplierButtonInteractableChange -= ChangeScoreMultiplierButtonInteractable;
            _garageComponent.OnGoldMultiplierButtonInteractableChange -= ChangeGoldMultiplierButtonInteractable;
            _garageComponent.OnShildeoButtonInteractableChange -= ChangeShildeoButtonInteractable;
            _garageComponent.OnBombeoButtonInteractableChange -= ChangeBombeoButtonInteractable;
            _garageComponent.OnGhosteoButtonInteractableChange -= ChangeGhosteoButtonInteractable;

            _garageComponent.OnHealthUpgradeChange -= ChangeHealthUpgrade;
            _garageComponent.OnSpeedUpgradeChange -= ChangeSpeedUpgrade;
            _garageComponent.OnCannonUpgradeChange -= ChangeCannonUpgrade;
            _garageComponent.OnPowerUpgradeChange -= ChangePowerUpgrade;
            _garageComponent.OnFireRateUpgradeChange -= ChangeFireRateUpgrade;
            _garageComponent.OnScoreMultiplierUpgradeChange -= ChangeScoreMultiplierUpgrade;
            _garageComponent.OnGoldMultiplierUpgradeChange -= ChangeGoldMultiplierUpgrade;
            _garageComponent.OnShildeoUpgradeChange -= ChangeShildeoUpgrade;
            _garageComponent.OnBombeoUpgradeChange -= ChangeBombeoUpgrade;
            _garageComponent.OnGhosteoUpgradeChange -= ChangeGhosteoUpgrade;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _garageCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;

            _garageCanvas.OnHealthUpgradeRequest += RequestHealthUpgrade;
            _garageCanvas.OnSpeedUpgradeRequest += RequestSpeedUpgrade;
            _garageCanvas.OnCannonUpgradeRequest += RequestCannonUpgrade;
            _garageCanvas.OnPowerUpgradeRequest += RequestPowerUpgrade;
            _garageCanvas.OnFireRateUpgradeRequest += RequestFireRateUpgrade;
            _garageCanvas.OnScoreMultiplierUpgradeRequest += RequestScoreMultiplierUpgrade;
            _garageCanvas.OnGoldMultiplierUpgradeRequest += RequestGoldMultiplierUpgrade;
            _garageCanvas.OnShildeoUpgradeRequest += RequestShildeoUpgrade;
            _garageCanvas.OnBombeoUpgradeRequest += RequestBombeoUpgrade;
            _garageCanvas.OnGhosteoUpgradeRequest += RequestGhosteoUpgrade;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _garageCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;

            _garageCanvas.OnHealthUpgradeRequest -= RequestHealthUpgrade;
            _garageCanvas.OnSpeedUpgradeRequest -= RequestSpeedUpgrade;
            _garageCanvas.OnCannonUpgradeRequest -= RequestCannonUpgrade;
            _garageCanvas.OnPowerUpgradeRequest -= RequestPowerUpgrade;
            _garageCanvas.OnFireRateUpgradeRequest -= RequestFireRateUpgrade;
            _garageCanvas.OnScoreMultiplierUpgradeRequest -= RequestScoreMultiplierUpgrade;
            _garageCanvas.OnGoldMultiplierUpgradeRequest -= RequestGoldMultiplierUpgrade;
            _garageCanvas.OnShildeoUpgradeRequest -= RequestShildeoUpgrade;
            _garageCanvas.OnBombeoUpgradeRequest -= RequestBombeoUpgrade;
            _garageCanvas.OnGhosteoUpgradeRequest -= RequestGhosteoUpgrade;
        }

        #region Changes

        private void ChangeGoldAmount(string ownedGold)
        {
            _garageCanvas.SetGold(ownedGold);
        }

        private void ChangeHealthUpgrade(int level, string cost)
        {
            _garageCanvas.SetHealth(level, cost);
        }

        private void ChangeSpeedUpgrade(int level, string cost)
        {
            _garageCanvas.SetSpeed(level, cost);
        }

        private void ChangeCannonUpgrade(int level, string cost)
        {
            _garageCanvas.SetCannon(level, cost);
        }

        private void ChangePowerUpgrade(int level, string cost)
        {
            _garageCanvas.SetPower(level, cost);
        }

        private void ChangeFireRateUpgrade(int level, string cost)
        {
            _garageCanvas.SetFireRate(level, cost);
        }

        private void ChangeGoldMultiplierUpgrade(int level, string cost)
        {
            _garageCanvas.SetGoldMultiplier(level, cost);
        }

        private void ChangeScoreMultiplierUpgrade(int level, string cost)
        {
            _garageCanvas.SetScoreMultiplier(level, cost);
        }

        private void ChangeShildeoUpgrade(int level, string cost)
        {
            _garageCanvas.SetShildeo(level, cost);
        }

        private void ChangeBombeoUpgrade(int level, string cost)
        {
            _garageCanvas.SetBombeo(level, cost);
        }

        private void ChangeGhosteoUpgrade(int level, string cost)
        {
            _garageCanvas.SetGhosteo(level, cost);
        }

        private void ChangeHealthButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetHealthButtonInteractable(isInteractable);
        }

        private void ChangeSpeedButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetSpeedButtonInteractable(isInteractable);
        }

        private void ChangeCannonButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetCannonButtonInteractable(isInteractable);
        }

        private void ChangePowerButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetPowerButtonInteractable(isInteractable);
        }

        private void ChangeFireRateButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetFireRateButtonInteractable(isInteractable);
        }

        private void ChangeScoreMultiplierButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetScoreMultiplierButtonInteractable(isInteractable);
        }

        private void ChangeGoldMultiplierButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetGoldMultiplierButtonInteractable(isInteractable);
        }

        private void ChangeShildeoButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetShildeoButtonInteractable(isInteractable);
        }

        private void ChangeBombeoButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetBombeoButtonInteractable(isInteractable);
        }

        private void ChangeGhosteoButtonInteractable(bool isInteractable)
        {
            _garageCanvas.SetGhosteoButtonInteractable(isInteractable);
        }

        #endregion

        #region Requests

        private void RequestHealthUpgrade()
        {
            _garageComponent.UpgradeHealth();
        }

        private void RequestSpeedUpgrade()
        {
            _garageComponent.UpgradeSpeed();
        }

        private void RequestCannonUpgrade()
        {
            _garageComponent.UpgradeCannon();
        }

        private void RequestPowerUpgrade()
        {
            _garageComponent.UpgradePower();
        }

        private void RequestFireRateUpgrade()
        {
            _garageComponent.UpgradeFireRate();
        }

        private void RequestScoreMultiplierUpgrade()
        {
            _garageComponent.UpgradeScoreMultiplier();
        }

        private void RequestGoldMultiplierUpgrade()
        {
            _garageComponent.UpgradeGoldMultiplier();
        }

        private void RequestShildeoUpgrade()
        {
            _garageComponent.UpgradeShildeo();
        }

        private void RequestBombeoUpgrade()
        {
            _garageComponent.UpgradeBombeo();
        }

        private void RequestGhosteoUpgrade()
        {
            _garageComponent.UpgradeGhosteo();
        }

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTrigger.ReturnToMainMenu);
        }

        #endregion
    }
}