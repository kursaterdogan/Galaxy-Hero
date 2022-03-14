using System;
using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class GarageComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        private const int MaxLevel = 6;
        private const int CostMultiplier = 500;
        private const string MaxLevelText = "";

        public delegate void GarageCoinChangeDelegate(string ownedCoin);

        public event GarageCoinChangeDelegate OnCoinAmountChange;

        public delegate void GarageButtonChangeDelegate(bool isInteractable);

        public event GarageButtonChangeDelegate OnHealthButtonInteractableChange;
        public event GarageButtonChangeDelegate OnSpeedButtonInteractableChange;
        public event GarageButtonChangeDelegate OnCannonButtonInteractableChange;
        public event GarageButtonChangeDelegate OnPowerButtonInteractableChange;
        public event GarageButtonChangeDelegate OnFireRateButtonInteractableChange;
        public event GarageButtonChangeDelegate OnScoreMultiplierButtonInteractableChange;
        public event GarageButtonChangeDelegate OnGoldMultiplierButtonInteractableChange;
        public event GarageButtonChangeDelegate OnShildeoButtonInteractableChange;
        public event GarageButtonChangeDelegate OnBombeoButtonInteractableChange;
        public event GarageButtonChangeDelegate OnGhosteoButtonInteractableChange;

        public delegate void GarageLevelChangeDelegate(int level, string cost);

        public event GarageLevelChangeDelegate OnHealthUpgradeChange;
        public event GarageLevelChangeDelegate OnSpeedUpgradeChange;
        public event GarageLevelChangeDelegate OnCannonUpgradeChange;
        public event GarageLevelChangeDelegate OnPowerUpgradeChange;
        public event GarageLevelChangeDelegate OnFireRateUpgradeChange;
        public event GarageLevelChangeDelegate OnScoreMultiplierUpgradeChange;
        public event GarageLevelChangeDelegate OnGoldMultiplierUpgradeChange;
        public event GarageLevelChangeDelegate OnShildeoUpgradeChange;
        public event GarageLevelChangeDelegate OnBombeoUpgradeChange;
        public event GarageLevelChangeDelegate OnGhosteoUpgradeChange;

        private event Action OnUpgradeAction;

        private DataComponent _dataComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
            //TODO Handle GarageComponent

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
        }

        public void OnConstruct()
        {
            SubscribeToOnUpgradeAction();
            SetUpgrades();
        }

        public void OnDestruct()
        {
            UnsubscribeToOnUpgradeAction();
        }

        private void SetUpgrades()
        {
            OnUpgradeAction?.Invoke();
            SetHealth();
            SetSpeed();
            SetCannon();
            SetPower();
            SetFireRate();
            SetScoreMultiplier();
            SetGoldMultiplier();
            SetShildeo();
            SetBombeo();
            SetGhosteo();
        }

        private void SubscribeToOnUpgradeAction()
        {
            OnUpgradeAction += SetCoin;
            OnUpgradeAction += SetHealthButtonInteractable;
            OnUpgradeAction += SetSpeedButtonInteractable;
            OnUpgradeAction += SetCannonButtonInteractable;
            OnUpgradeAction += SetPowerButtonInteractable;
            OnUpgradeAction += SetFireRateButtonInteractable;
            OnUpgradeAction += SetScoreMultiplierButtonInteractable;
            OnUpgradeAction += SetGoldMultiplierButtonInteractable;
            OnUpgradeAction += SetShildeoButtonInteractable;
            OnUpgradeAction += SetBombeoButtonInteractable;
            OnUpgradeAction += SetGhosteoButtonInteractable;
        }

        private void UnsubscribeToOnUpgradeAction()
        {
            OnUpgradeAction -= SetCoin;
            OnUpgradeAction -= SetHealthButtonInteractable;
            OnUpgradeAction -= SetSpeedButtonInteractable;
            OnUpgradeAction -= SetCannonButtonInteractable;
            OnUpgradeAction -= SetPowerButtonInteractable;
            OnUpgradeAction -= SetFireRateButtonInteractable;
            OnUpgradeAction -= SetScoreMultiplierButtonInteractable;
            OnUpgradeAction -= SetGoldMultiplierButtonInteractable;
            OnUpgradeAction -= SetShildeoButtonInteractable;
            OnUpgradeAction -= SetBombeoButtonInteractable;
            OnUpgradeAction -= SetGhosteoButtonInteractable;
        }

        private void SetCoin()
        {
            int ownedCoin = _dataComponent.CoinData.ownedCoin;

            OnCoinAmountChange?.Invoke(ownedCoin.ToString());
        }

        private void SetHealth()
        {
            int level = _dataComponent.GarageData.healthLevel;
            string cost = GetCost(level);

            OnHealthUpgradeChange?.Invoke(level, cost);
        }

        private void SetSpeed()
        {
            int level = _dataComponent.GarageData.speedLevel;
            string cost = GetCost(level);

            OnSpeedUpgradeChange?.Invoke(level, cost);
        }

        private void SetCannon()
        {
            int level = _dataComponent.GarageData.cannonLevel;
            string cost = GetCost(level);

            OnCannonUpgradeChange?.Invoke(level, cost);
        }

        private void SetPower()
        {
            int level = _dataComponent.GarageData.powerLevel;
            string cost = GetCost(level);

            OnPowerUpgradeChange?.Invoke(level, cost);
        }

        private void SetFireRate()
        {
            int level = _dataComponent.GarageData.fireRateLevel;
            string cost = GetCost(level);

            OnFireRateUpgradeChange?.Invoke(level, cost);
        }

        private void SetScoreMultiplier()
        {
            int level = _dataComponent.GarageData.scoreMultiplierLevel;
            string cost = GetCost(level);

            OnScoreMultiplierUpgradeChange?.Invoke(level, cost);
        }

        private void SetGoldMultiplier()
        {
            int level = _dataComponent.GarageData.goldMultiplierLevel;
            string cost = GetCost(level);

            OnGoldMultiplierUpgradeChange?.Invoke(level, cost);
        }

        private void SetShildeo()
        {
            int level = _dataComponent.GarageData.shildeoLevel;
            string cost = GetCost(level);

            OnShildeoUpgradeChange?.Invoke(level, cost);
        }

        private void SetBombeo()
        {
            int level = _dataComponent.GarageData.bombeoLevel;
            string cost = GetCost(level);

            OnBombeoUpgradeChange?.Invoke(level, cost);
        }

        private void SetGhosteo()
        {
            int level = _dataComponent.GarageData.ghosteoLevel;
            string cost = GetCost(level);

            OnGhosteoUpgradeChange?.Invoke(level, cost);
        }

        private void SetHealthButtonInteractable()
        {
            int level = _dataComponent.GarageData.healthLevel;
            bool isInteractable = IsPurchasable(level);

            OnHealthButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetSpeedButtonInteractable()
        {
            int level = _dataComponent.GarageData.speedLevel;
            bool isInteractable = IsPurchasable(level);

            OnSpeedButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetCannonButtonInteractable()
        {
            int level = _dataComponent.GarageData.cannonLevel;
            bool isInteractable = IsPurchasable(level);

            OnCannonButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetPowerButtonInteractable()
        {
            int level = _dataComponent.GarageData.powerLevel;
            bool isInteractable = IsPurchasable(level);

            OnPowerButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetFireRateButtonInteractable()
        {
            int level = _dataComponent.GarageData.fireRateLevel;
            bool isInteractable = IsPurchasable(level);

            OnFireRateButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetScoreMultiplierButtonInteractable()
        {
            int level = _dataComponent.GarageData.scoreMultiplierLevel;
            bool isInteractable = IsPurchasable(level);

            OnScoreMultiplierButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetGoldMultiplierButtonInteractable()
        {
            int level = _dataComponent.GarageData.goldMultiplierLevel;
            bool isInteractable = IsPurchasable(level);

            OnGoldMultiplierButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetShildeoButtonInteractable()
        {
            int level = _dataComponent.GarageData.shildeoLevel;
            bool isInteractable = IsPurchasable(level);

            OnShildeoButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetBombeoButtonInteractable()
        {
            int level = _dataComponent.GarageData.bombeoLevel;
            bool isInteractable = IsPurchasable(level);

            OnBombeoButtonInteractableChange?.Invoke(isInteractable);
        }

        private void SetGhosteoButtonInteractable()
        {
            int level = _dataComponent.GarageData.ghosteoLevel;
            bool isInteractable = IsPurchasable(level);

            OnGhosteoButtonInteractableChange?.Invoke(isInteractable);
        }

        private string GetCost(int level)
        {
            if (level == MaxLevel)
                return MaxLevelText;

            return (level * CostMultiplier).ToString();
        }

        private bool IsPurchasable(int level)
        {
            int ownedCoin = _dataComponent.CoinData.ownedCoin;
            bool isPurchasable = ownedCoin >= level * CostMultiplier && level != MaxLevel;

            return isPurchasable;
        }
    }
}