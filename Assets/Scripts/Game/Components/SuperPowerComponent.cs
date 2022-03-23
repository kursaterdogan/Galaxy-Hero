using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class SuperPowerComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public enum SuperPowerName
        {
            Shildeo,
            Bombeo,
            Ghosteo
        }

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

        private const int SuperPowerDuration = 30;

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

        public SuperPowerName GetSelectedSuperPower()
        {
            //TODO Handle in Gameplay
            int selectedSuperPower = _dataComponent.SuperPowerData.selectedSuperPower;
            SuperPowerName superPowerName = (SuperPowerName)selectedSuperPower;

            return superPowerName;
        }

        public int GetSuperPowerDuration()
        {
            //TODO Handle in Gameplay
            return SuperPowerDuration;
        }

        #region Requests

        public void RequestLeftSelectionButton()
        {
            SuperPowerName activeSuperPower = GetSelectedSuperPower();

            switch (activeSuperPower)
            {
                case SuperPowerName.Shildeo:
                    return;
                case SuperPowerName.Bombeo:
                    SetSelectedSuperPower(SuperPowerName.Shildeo);
                    ChangeLeftSelectionButtonInteractable(false);
                    ActivateShildeo();
                    break;
                case SuperPowerName.Ghosteo:
                    SetSelectedSuperPower(SuperPowerName.Bombeo);
                    ChangeRightSelectionButtonInteractable(true);
                    ActivateBombeo();
                    break;
            }
        }

        public void RequestRightSelectionButton()
        {
            SuperPowerName activeSuperPower = GetSelectedSuperPower();

            switch (activeSuperPower)
            {
                case SuperPowerName.Ghosteo:
                    return;
                case SuperPowerName.Shildeo:
                    SetSelectedSuperPower(SuperPowerName.Bombeo);
                    ChangeLeftSelectionButtonInteractable(true);
                    ActivateBombeo();
                    break;
                case SuperPowerName.Bombeo:
                    SetSelectedSuperPower(SuperPowerName.Ghosteo);
                    ChangeRightSelectionButtonInteractable(false);
                    ActivateGhosteo();
                    break;
            }
        }

        #endregion

        #region Changes

        private void ChangeShildeoDescription()
        {
            int level = _dataComponent.GarageData.shildeoLevel;
            string description = "Every " + SuperPowerDuration + " Seconds Gain Shield For " + level +
                                 " Seconds";

            OnShildeoDescriptionChange?.Invoke(description);
        }

        private void ChangeBombeoDescription()
        {
            int level = _dataComponent.GarageData.bombeoLevel;
            string description = "Every " + SuperPowerDuration + " Seconds Fire Bomb With " + level + " Power";

            OnBombeoDescriptionChange?.Invoke(description);
        }

        private void ChangeGhosteoDescription()
        {
            int level = _dataComponent.GarageData.ghosteoLevel;
            string description = "Every " + SuperPowerDuration + " Seconds Become Immune For " + level +
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
            SuperPowerName activeSuperPower = GetSelectedSuperPower();

            switch (activeSuperPower)
            {
                case SuperPowerName.Shildeo:
                    ChangeLeftSelectionButtonInteractable(false);
                    ChangeRightSelectionButtonInteractable(true);
                    ActivateShildeo();
                    break;
                case SuperPowerName.Bombeo:
                    ChangeLeftSelectionButtonInteractable(true);
                    ChangeRightSelectionButtonInteractable(true);
                    ActivateBombeo();
                    break;
                case SuperPowerName.Ghosteo:
                    ChangeLeftSelectionButtonInteractable(true);
                    ChangeRightSelectionButtonInteractable(false);
                    ActivateGhosteo();
                    break;
            }
        }

        #endregion

        private void SetSelectedSuperPower(SuperPowerName selectedSuperPower)
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