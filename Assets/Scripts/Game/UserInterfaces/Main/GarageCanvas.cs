using UnityEngine;
using UnityEngine.UI;
using Base.UserInterface;
using TMPro;

namespace Game.UserInterfaces.Main
{
    public class GarageCanvas : BaseCanvas
    {
        public delegate void GarageRequestDelegate();

        public event GarageRequestDelegate OnHealthUpgradeRequest;
        public event GarageRequestDelegate OnSpeedUpgradeRequest;
        public event GarageRequestDelegate OnCannonUpgradeRequest;
        public event GarageRequestDelegate OnPowerUpgradeRequest;
        public event GarageRequestDelegate OnFireRateUpgradeRequest;
        public event GarageRequestDelegate OnScoreMultiplierUpgradeRequest;
        public event GarageRequestDelegate OnGoldMultiplierUpgradeRequest;
        public event GarageRequestDelegate OnShildeoUpgradeRequest;
        public event GarageRequestDelegate OnBombeoUpgradeRequest;
        public event GarageRequestDelegate OnGhosteoUpgradeRequest;

        public event GarageRequestDelegate OnReturnToMainMenuRequest;

        [SerializeField] private TMP_Text coinText;

        [SerializeField] private TMP_Text healthCostText;
        [SerializeField] private TMP_Text healthLevelText;
        [SerializeField] private Button healthUpgradeButton;
        [SerializeField] private Image[] healthLevelFrames;

        [SerializeField] private TMP_Text speedCostText;
        [SerializeField] private TMP_Text speedLevelText;
        [SerializeField] private Button speedUpgradeButton;
        [SerializeField] private Image[] speedLevelFrames;

        [SerializeField] private TMP_Text cannonCostText;
        [SerializeField] private TMP_Text cannonLevelText;
        [SerializeField] private Button cannonUpgradeButton;
        [SerializeField] private Image[] cannonLevelFrames;

        [SerializeField] private TMP_Text powerCostText;
        [SerializeField] private TMP_Text powerLevelText;
        [SerializeField] private Button powerUpgradeButton;
        [SerializeField] private Image[] powerLevelFrames;

        [SerializeField] private TMP_Text fireRateCostText;
        [SerializeField] private TMP_Text fireRateLevelText;
        [SerializeField] private Button fireRateUpgradeButton;
        [SerializeField] private Image[] fireRateLevelFrames;

        [SerializeField] private TMP_Text scoreMultiplierCostText;
        [SerializeField] private TMP_Text scoreMultiplierLevelText;
        [SerializeField] private Button scoreMultiplierUpgradeButton;
        [SerializeField] private Image[] scoreMultiplierLevelFrames;

        [SerializeField] private TMP_Text goldMultiplierCostText;
        [SerializeField] private TMP_Text goldMultiplierLevelText;
        [SerializeField] private Button goldMultiplierUpgradeButton;
        [SerializeField] private Image[] goldMultiplierLevelFrames;

        [SerializeField] private TMP_Text shildeoCostText;
        [SerializeField] private TMP_Text shildeoLevelText;
        [SerializeField] private Button shildeoUpgradeButton;
        [SerializeField] private Image[] shildeoLevelFrames;

        [SerializeField] private TMP_Text bombeoCostText;
        [SerializeField] private TMP_Text bombeoLevelText;
        [SerializeField] private Button bombeoUpgradeButton;
        [SerializeField] private Image[] bombeoLevelFrames;

        [SerializeField] private TMP_Text ghosteoCostText;
        [SerializeField] private TMP_Text ghosteoLevelText;
        [SerializeField] private Button ghosteoUpgradeButton;
        [SerializeField] private Image[] ghosteoLevelFrames;

        #region Upgrade Changes

        public void SetCoin(string ownedCoin)
        {
            coinText.text = ownedCoin;
        }

        public void SetHealth(int level, string cost)
        {
            healthLevelText.text = level.ToString();
            healthCostText.text = cost;

            SetLevelFrames(level, healthLevelFrames);
        }

        public void SetSpeed(int level, string cost)
        {
            speedLevelText.text = level.ToString();
            speedCostText.text = cost;

            SetLevelFrames(level, speedLevelFrames);
        }

        public void SetCannon(int level, string cost)
        {
            cannonLevelText.text = level.ToString();
            cannonCostText.text = cost;

            SetLevelFrames(level, cannonLevelFrames);
        }

        public void SetPower(int level, string cost)
        {
            powerLevelText.text = level.ToString();
            powerCostText.text = cost;

            SetLevelFrames(level, powerLevelFrames);
        }

        public void SetFireRate(int level, string cost)
        {
            fireRateLevelText.text = level.ToString();
            fireRateCostText.text = cost;

            SetLevelFrames(level, fireRateLevelFrames);
        }

        public void SetScoreMultiplier(int level, string cost)
        {
            scoreMultiplierLevelText.text = level.ToString();
            scoreMultiplierCostText.text = cost;

            SetLevelFrames(level, scoreMultiplierLevelFrames);
        }

        public void SetGoldMultiplier(int level, string cost)
        {
            goldMultiplierLevelText.text = level.ToString();
            goldMultiplierCostText.text = cost;

            SetLevelFrames(level, goldMultiplierLevelFrames);
        }

        public void SetShildeo(int level, string cost)
        {
            shildeoLevelText.text = level.ToString();
            shildeoCostText.text = cost;

            SetLevelFrames(level, shildeoLevelFrames);
        }

        public void SetBombeo(int level, string cost)
        {
            bombeoLevelText.text = level.ToString();
            bombeoCostText.text = cost;

            SetLevelFrames(level, bombeoLevelFrames);
        }

        public void SetGhosteo(int level, string cost)
        {
            ghosteoLevelText.text = level.ToString();
            ghosteoCostText.text = cost;

            SetLevelFrames(level, ghosteoLevelFrames);
        }

        public void SetHealthButtonInteractable(bool isInteractable)
        {
            if (isInteractable != healthUpgradeButton.interactable)
                healthUpgradeButton.interactable = isInteractable;
        }

        public void SetSpeedButtonInteractable(bool isInteractable)
        {
            if (isInteractable != speedUpgradeButton.interactable)
                speedUpgradeButton.interactable = isInteractable;
        }

        public void SetCannonButtonInteractable(bool isInteractable)
        {
            if (isInteractable != cannonUpgradeButton.interactable)
                cannonUpgradeButton.interactable = isInteractable;
        }

        public void SetPowerButtonInteractable(bool isInteractable)
        {
            if (isInteractable != powerUpgradeButton.interactable)
                powerUpgradeButton.interactable = isInteractable;
        }

        public void SetFireRateButtonInteractable(bool isInteractable)
        {
            if (isInteractable != fireRateUpgradeButton.interactable)
                fireRateUpgradeButton.interactable = isInteractable;
        }

        public void SetScoreMultiplierButtonInteractable(bool isInteractable)
        {
            if (isInteractable != scoreMultiplierUpgradeButton.interactable)
                scoreMultiplierUpgradeButton.interactable = isInteractable;
        }

        public void SetGoldMultiplierButtonInteractable(bool isInteractable)
        {
            if (isInteractable != goldMultiplierUpgradeButton.interactable)
                goldMultiplierUpgradeButton.interactable = isInteractable;
        }

        public void SetShildeoButtonInteractable(bool isInteractable)
        {
            if (isInteractable != shildeoUpgradeButton.interactable)
                shildeoUpgradeButton.interactable = isInteractable;
        }

        public void SetBombeoButtonInteractable(bool isInteractable)
        {
            if (isInteractable != bombeoUpgradeButton.interactable)
                bombeoUpgradeButton.interactable = isInteractable;
        }

        public void SetGhosteoButtonInteractable(bool isInteractable)
        {
            if (isInteractable != ghosteoUpgradeButton.interactable)
                ghosteoUpgradeButton.interactable = isInteractable;
        }

        #endregion

        #region Upgrade Requests

        public void RequestHealthUpgrade()
        {
            OnHealthUpgradeRequest?.Invoke();
        }

        public void RequestSpeedUpgrade()
        {
            OnSpeedUpgradeRequest?.Invoke();
        }

        public void RequestCanonUpgrade()
        {
            OnCannonUpgradeRequest?.Invoke();
        }

        public void RequestPowerUpgrade()
        {
            OnPowerUpgradeRequest?.Invoke();
        }

        public void RequestFireRateUpgrade()
        {
            OnFireRateUpgradeRequest?.Invoke();
        }

        public void RequestScoreMultiplierUpgrade()
        {
            OnScoreMultiplierUpgradeRequest?.Invoke();
        }

        public void RequestGoldMultiplierUpgrade()
        {
            OnGoldMultiplierUpgradeRequest?.Invoke();
        }

        public void RequestShildeoUpgrade()
        {
            OnShildeoUpgradeRequest?.Invoke();
        }

        public void RequestBombeoUpgrade()
        {
            OnBombeoUpgradeRequest?.Invoke();
        }

        public void RequestGhosteoUpgrade()
        {
            OnGhosteoUpgradeRequest?.Invoke();
        }

        #endregion

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainMenuRequest?.Invoke();
        }

        private void SetLevelFrames(int level, Image[] levelFrames)
        {
            for (int i = 0; i < level; i++)
            {
                if (!levelFrames[i].enabled)
                    levelFrames[i].enabled = true;
            }
        }
    }
}