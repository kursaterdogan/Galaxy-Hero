using UnityEngine;
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
        [SerializeField] private GameObject[] healthLevelFrames;

        [SerializeField] private TMP_Text speedCostText;
        [SerializeField] private TMP_Text speedLevelText;
        [SerializeField] private GameObject[] speedLevelFrames;

        [SerializeField] private TMP_Text cannonCostText;
        [SerializeField] private TMP_Text cannonLevelText;
        [SerializeField] private GameObject[] cannonLevelFrames;

        [SerializeField] private TMP_Text powerCostText;
        [SerializeField] private TMP_Text powerLevelText;
        [SerializeField] private GameObject[] powerLevelFrames;

        [SerializeField] private TMP_Text fireRateCostText;
        [SerializeField] private TMP_Text fireRateLevelText;
        [SerializeField] private GameObject[] fireRateLevelFrames;

        [SerializeField] private TMP_Text scoreMultiplierCostText;
        [SerializeField] private TMP_Text scoreMultiplierLevelText;
        [SerializeField] private GameObject[] scoreMultiplierLevelFrames;

        [SerializeField] private TMP_Text goldMultiplierCostText;
        [SerializeField] private TMP_Text goldMultiplierLevelText;
        [SerializeField] private GameObject[] goldMultiplierLevelFrames;

        [SerializeField] private TMP_Text shildeoCostText;
        [SerializeField] private TMP_Text shildeoLevelText;
        [SerializeField] private GameObject[] shildeoLevelFrames;

        [SerializeField] private TMP_Text bombeoCostText;
        [SerializeField] private TMP_Text bombeoLevelText;
        [SerializeField] private GameObject[] bombeoLevelFrames;

        [SerializeField] private TMP_Text ghosteoCostText;
        [SerializeField] private TMP_Text ghosteoLevelText;
        [SerializeField] private GameObject[] ghosteoLevelFrames;

        public void RequestHealthUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnHealthUpgradeRequest?.Invoke();
        }

        public void RequestSpeedUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnSpeedUpgradeRequest?.Invoke();
        }

        public void RequestCanonUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnCannonUpgradeRequest?.Invoke();
        }

        public void RequestPowerUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnPowerUpgradeRequest?.Invoke();
        }

        public void RequestFireRateUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnFireRateUpgradeRequest?.Invoke();
        }

        public void RequestScoreMultiplierUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnScoreMultiplierUpgradeRequest?.Invoke();
        }

        public void RequestGoldMultiplierUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnGoldMultiplierUpgradeRequest?.Invoke();
        }

        public void RequestShildeoUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnShildeoUpgradeRequest?.Invoke();
        }

        public void RequestBombeoUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnBombeoUpgradeRequest?.Invoke();
        }

        public void RequestGhosteoUpgrade()
        {
            //TODO Subscribe & Unsubscribe
            OnGhosteoUpgradeRequest?.Invoke();
        }

        public void RequestReturnToMainMenu()
        {
            //TODO Subscribe & Unsubscribe
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}