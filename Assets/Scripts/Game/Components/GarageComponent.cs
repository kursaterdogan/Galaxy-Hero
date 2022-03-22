using System;
using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class GarageComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        private const int MaxLevel = 6;
        private const int CostMultiplier = 500;
        private const string MaxLevelText = "MAX";

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
            SaveDatas();
        }

        #region Upgrade Requests

        public void UpgradeHealth()
        {
            int level = _dataComponent.GarageData.healthLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.healthLevel++;
            SetHealth();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeSpeed()
        {
            int level = _dataComponent.GarageData.speedLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.speedLevel++;
            SetSpeed();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeCannon()
        {
            int level = _dataComponent.GarageData.cannonLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.cannonLevel++;
            SetCannon();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradePower()
        {
            int level = _dataComponent.GarageData.powerLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.powerLevel++;
            SetPower();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeFireRate()
        {
            int level = _dataComponent.GarageData.fireRateLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.fireRateLevel++;
            SetFireRate();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeScoreMultiplier()
        {
            int level = _dataComponent.GarageData.scoreMultiplierLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.scoreMultiplierLevel++;
            SetScoreMultiplier();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeGoldMultiplier()
        {
            int level = _dataComponent.GarageData.goldMultiplierLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.goldMultiplierLevel++;
            SetGoldMultiplier();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeShildeo()
        {
            int level = _dataComponent.GarageData.shildeoLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.shildeoLevel++;
            SetShildeo();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeBombeo()
        {
            int level = _dataComponent.GarageData.bombeoLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.bombeoLevel++;
            SetBombeo();
            OnUpgradeAction?.Invoke();
        }

        public void UpgradeGhosteo()
        {
            int level = _dataComponent.GarageData.ghosteoLevel;

            if (!IsPurchasable(level))
                return;

            BuyUpgrade(level);
            _dataComponent.GarageData.ghosteoLevel++;
            SetGhosteo();
            OnUpgradeAction?.Invoke();
        }

        #endregion

        private bool IsPurchasable(int level)
        {
            int ownedCoin = _dataComponent.CoinData.ownedCoin;
            bool isPurchasable = level != MaxLevel && ownedCoin >= GetCost(level);

            return isPurchasable;
        }

        private void BuyUpgrade(int level)
        {
            int cost = GetCost(level);

            _dataComponent.CoinData.ownedCoin -= cost;
        }

        private int GetCost(int level)
        {
            return level * level * CostMultiplier;
        }

        private string GetCostText(int level)
        {
            if (level == MaxLevel)
                return MaxLevelText;

            return GetCost(level).ToString();
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

        private void SaveDatas()
        {
            _dataComponent.SaveCoinData();
            _dataComponent.SaveGarageData();
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

        #region Upgrade Changes

        private void SetCoin()
        {
            int ownedCoin = _dataComponent.CoinData.ownedCoin;

            OnCoinAmountChange?.Invoke(ownedCoin.ToString());
        }

        private void SetHealth()
        {
            int level = _dataComponent.GarageData.healthLevel;
            string cost = GetCostText(level);

            OnHealthUpgradeChange?.Invoke(level, cost);
        }

        private void SetSpeed()
        {
            int level = _dataComponent.GarageData.speedLevel;
            string cost = GetCostText(level);

            OnSpeedUpgradeChange?.Invoke(level, cost);
        }

        private void SetCannon()
        {
            int level = _dataComponent.GarageData.cannonLevel;
            string cost = GetCostText(level);

            OnCannonUpgradeChange?.Invoke(level, cost);
        }

        private void SetPower()
        {
            int level = _dataComponent.GarageData.powerLevel;
            string cost = GetCostText(level);

            OnPowerUpgradeChange?.Invoke(level, cost);
        }

        private void SetFireRate()
        {
            int level = _dataComponent.GarageData.fireRateLevel;
            string cost = GetCostText(level);

            OnFireRateUpgradeChange?.Invoke(level, cost);
        }

        private void SetScoreMultiplier()
        {
            int level = _dataComponent.GarageData.scoreMultiplierLevel;
            string cost = GetCostText(level);

            OnScoreMultiplierUpgradeChange?.Invoke(level, cost);
        }

        private void SetGoldMultiplier()
        {
            int level = _dataComponent.GarageData.goldMultiplierLevel;
            string cost = GetCostText(level);

            OnGoldMultiplierUpgradeChange?.Invoke(level, cost);
        }

        private void SetShildeo()
        {
            int level = _dataComponent.GarageData.shildeoLevel;
            string cost = GetCostText(level);

            OnShildeoUpgradeChange?.Invoke(level, cost);
        }

        private void SetBombeo()
        {
            int level = _dataComponent.GarageData.bombeoLevel;
            string cost = GetCostText(level);

            OnBombeoUpgradeChange?.Invoke(level, cost);
        }

        private void SetGhosteo()
        {
            int level = _dataComponent.GarageData.ghosteoLevel;
            string cost = GetCostText(level);

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

        #endregion
    }
}