using UnityEngine;
using UnityEngine.UI;
using Base.UserInterface;
using TMPro;

namespace Game.UserInterfaces.Main
{
    public class SuperPowerCanvas : BaseCanvas, IQuittable
    {
        public delegate void SuperPowerRequestDelegate();

        public event SuperPowerRequestDelegate OnLeftSelectionRequest;
        public event SuperPowerRequestDelegate OnRightSelectionRequest;
        public event SuperPowerRequestDelegate OnReturnToMainMenuRequest;

        [SerializeField] private Button leftSelectionButton;
        [SerializeField] private Button rightSelectionButton;

        [SerializeField] private GameObject shildeo;
        [SerializeField] private GameObject bombeo;
        [SerializeField] private GameObject ghosteo;

        [SerializeField] private TMP_Text shildeoDescriptionText;
        [SerializeField] private TMP_Text bombeoDescriptionText;
        [SerializeField] private TMP_Text ghosteoDescriptionText;

        public void OnQuit()
        {
            DeactivateSuperPowers();
        }

        #region Changes

        public void SetShildeoDescriptionText(string description)
        {
            shildeoDescriptionText.text = description;
        }

        public void SetBombeoDescriptionText(string description)
        {
            bombeoDescriptionText.text = description;
        }

        public void SetGhosteoDescriptionText(string description)
        {
            ghosteoDescriptionText.text = description;
        }

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

        public void ActivateShildeo()
        {
            DeactivateSuperPowers();
            shildeo.SetActive(true);
        }

        public void ActivateBombeo()
        {
            DeactivateSuperPowers();
            bombeo.SetActive(true);
        }

        public void ActivateGhosteo()
        {
            DeactivateSuperPowers();
            ghosteo.SetActive(true);
        }

        #endregion

        #region Requests

        public void RequestLeftSelection()
        {
            OnLeftSelectionRequest?.Invoke();
        }

        public void RequestRightSelection()
        {
            OnRightSelectionRequest?.Invoke();
        }

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainMenuRequest?.Invoke();
        }

        #endregion

        private void DeactivateSuperPowers()
        {
            GameObject[] superPowers = { shildeo, bombeo, ghosteo };

            foreach (GameObject superPower in superPowers)
            {
                if (superPower.activeInHierarchy)
                    superPower.SetActive(false);
            }
        }
    }
}