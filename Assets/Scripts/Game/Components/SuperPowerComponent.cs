using UnityEngine;
using Base.Component;
using Game.Enums;

namespace Game.Components
{
    public class SuperPowerComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void DescriptionChangeDelegate(string description);

        public event DescriptionChangeDelegate OnShildeoDescriptionChange;
        public event DescriptionChangeDelegate OnBombeoDescriptionChange;
        public event DescriptionChangeDelegate OnGhosteoDescriptionChange;

        public delegate void SelectionButtonChangeDelegate(bool isInteractable);

        public event SelectionButtonChangeDelegate OnLeftSelectionButtonInteractableChange;
        public event SelectionButtonChangeDelegate OnRightSelectionButtonInteractableChange;

        public delegate void SuperPowerChangeDelegate();

        public event SuperPowerChangeDelegate OnActivateShildeo;
        public event SuperPowerChangeDelegate OnActivateBombeo;
        public event SuperPowerChangeDelegate OnActivateGhosteo;

        private const int _superPowerCooldown = 30;
        private const int _superPowerDurationMultiplier = 3;

        private DataComponent _dataComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
        }

        public void OnConstruct()
        {
            ChangeShildeoDescription();
            ChangeBombeoDescription();
            ChangeGhosteoDescription();
            SetActiveSuperPower();
        }

        public void OnDestruct()
        {
            SaveSuperPowerData();
        }

        public float GetSuperPowerCooldown()
        {
            return _superPowerCooldown;
        }

        public int GetSuperPowerDurationMultiplier()
        {
            return _superPowerDurationMultiplier;
        }

        #region Requests

        public void RequestLeftSelectionButton()
        {
            SuperPower activeSuperPower = GetSelectedSuperPower();

            switch (activeSuperPower)
            {
                case SuperPower.Shildeo:
                    return;
                case SuperPower.Bombeo:
                    SetSelectedSuperPower(SuperPower.Shildeo);
                    ChangeLeftSelectionButtonInteractable(false);
                    ActivateShildeo();
                    break;
                case SuperPower.Ghosteo:
                    SetSelectedSuperPower(SuperPower.Bombeo);
                    ChangeRightSelectionButtonInteractable(true);
                    ActivateBombeo();
                    break;
            }
        }

        public void RequestRightSelectionButton()
        {
            SuperPower activeSuperPower = GetSelectedSuperPower();

            switch (activeSuperPower)
            {
                case SuperPower.Ghosteo:
                    return;
                case SuperPower.Shildeo:
                    SetSelectedSuperPower(SuperPower.Bombeo);
                    ChangeLeftSelectionButtonInteractable(true);
                    ActivateBombeo();
                    break;
                case SuperPower.Bombeo:
                    SetSelectedSuperPower(SuperPower.Ghosteo);
                    ChangeRightSelectionButtonInteractable(false);
                    ActivateGhosteo();
                    break;
            }
        }

        #endregion

        #region Changes

        private void ChangeShildeoDescription()
        {
            int level = _dataComponent.GarageData.shildeoLevel * _superPowerDurationMultiplier;
            string description = "Every " + _superPowerCooldown + " Seconds Gain Shield For " + level +
                                 " Seconds";

            OnShildeoDescriptionChange?.Invoke(description);
        }

        private void ChangeBombeoDescription()
        {
            int level = _dataComponent.GarageData.bombeoLevel;
            string description = "Every " + _superPowerCooldown + " Seconds Fire Bomb With " + level + " Size";

            OnBombeoDescriptionChange?.Invoke(description);
        }

        private void ChangeGhosteoDescription()
        {
            int level = _dataComponent.GarageData.ghosteoLevel * _superPowerDurationMultiplier;
            string description = "Every " + _superPowerCooldown + " Seconds Become Immune For " + level +
                                 " Seconds";

            OnGhosteoDescriptionChange?.Invoke(description);
        }

        private void ChangeLeftSelectionButtonInteractable(bool isInteractable)
        {
            OnLeftSelectionButtonInteractableChange?.Invoke(isInteractable);
        }

        private void ChangeRightSelectionButtonInteractable(bool isInteractable)
        {
            OnRightSelectionButtonInteractableChange?.Invoke(isInteractable);
        }

        private void ActivateShildeo()
        {
            OnActivateShildeo?.Invoke();
        }

        private void ActivateBombeo()
        {
            OnActivateBombeo?.Invoke();
        }

        private void ActivateGhosteo()
        {
            OnActivateGhosteo?.Invoke();
        }

        private void SetActiveSuperPower()
        {
            SuperPower activeSuperPower = GetSelectedSuperPower();

            switch (activeSuperPower)
            {
                case SuperPower.Shildeo:
                    ChangeLeftSelectionButtonInteractable(false);
                    ChangeRightSelectionButtonInteractable(true);
                    ActivateShildeo();
                    break;
                case SuperPower.Bombeo:
                    ChangeLeftSelectionButtonInteractable(true);
                    ChangeRightSelectionButtonInteractable(true);
                    ActivateBombeo();
                    break;
                case SuperPower.Ghosteo:
                    ChangeLeftSelectionButtonInteractable(true);
                    ChangeRightSelectionButtonInteractable(false);
                    ActivateGhosteo();
                    break;
            }
        }

        #endregion

        private SuperPower GetSelectedSuperPower()
        {
            int selectedSuperPower = _dataComponent.SuperPowerData.selectedSuperPower;
            SuperPower superPower = (SuperPower)selectedSuperPower;

            return superPower;
        }

        private void SetSelectedSuperPower(SuperPower selectedSuperPower)
        {
            int selectedSuperPowerIndex = (int)selectedSuperPower;

            _dataComponent.SuperPowerData.selectedSuperPower = selectedSuperPowerIndex;
        }

        private void SaveSuperPowerData()
        {
            _dataComponent.SaveSuperPowerData();
        }
    }
}