using UnityEngine;
using UnityEngine.UI;
using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class MainMenuCanvas : BaseCanvas, IQuittable
    {
        public delegate void MainMenuRequestDelegate();

        public event MainMenuRequestDelegate OnLeftSelectionRequest;
        public event MainMenuRequestDelegate OnRightSelectionRequest;

        public event MainMenuRequestDelegate OnInventoryRequest;
        public event MainMenuRequestDelegate OnGarageRequest;
        public event MainMenuRequestDelegate OnSuperPowerRequest;
        public event MainMenuRequestDelegate OnCreditsRequest;
        public event MainMenuRequestDelegate OnAchievementRequest;
        public event MainMenuRequestDelegate OnInGameRequest;

        [SerializeField] private Button leftSelectionButton;
        [SerializeField] private Button rightSelectionButton;

        [SerializeField] private GameObject saturn;
        [SerializeField] private GameObject mars;

        public void OnQuit()
        {
            DeactivatePlanets();
        }

        #region Changes

        public void SetLeftSelectionButtonInteractable(bool isInteractable)
        {
            if (isInteractable != leftSelectionButton.interactable)
                leftSelectionButton.interactable = isInteractable;
        }

        public void SetRightSelectionButtonInteractable(bool isInteractable)
        {
            if (isInteractable != rightSelectionButton.interactable)
                rightSelectionButton.interactable = isInteractable;
        }

        public void ActivateSaturn()
        {
            DeactivatePlanets();
            saturn.SetActive(true);
        }

        public void ActivateMars()
        {
            DeactivatePlanets();
            mars.SetActive(true);
        }

        #endregion

        #region Requests

        public void RequestInventory()
        {
            OnInventoryRequest?.Invoke();
        }

        public void RequestGarage()
        {
            OnGarageRequest?.Invoke();
        }

        public void RequestSuperPower()
        {
            OnSuperPowerRequest?.Invoke();
        }

        public void RequestCredits()
        {
            OnCreditsRequest?.Invoke();
        }

        public void RequestAchievement()
        {
            OnAchievementRequest?.Invoke();
        }

        public void RequestLeftSelection()
        {
            OnLeftSelectionRequest?.Invoke();
        }

        public void RequestRightSelection()
        {
            OnRightSelectionRequest?.Invoke();
        }

        public void RequestInGameMenu()
        {
            OnInGameRequest?.Invoke();
        }

        #endregion

        private void DeactivatePlanets()
        {
            GameObject[] planets = { saturn, mars };

            foreach (GameObject planet in planets)
            {
                if (planet.activeInHierarchy)
                    planet.SetActive(false);
            }
        }
    }
}