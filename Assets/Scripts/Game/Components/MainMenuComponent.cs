using UnityEngine;
using Base.Component;
using Game.Enums;

namespace Game.Components
{
    public class MainMenuComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void SelectionButtonChangeDelegate(bool isInteractable);

        public event SelectionButtonChangeDelegate OnLeftSelectionButtonInteractableChange;
        public event SelectionButtonChangeDelegate OnRightSelectionButtonInteractableChange;

        public delegate void MainMenuChangeDelegate();

        public event MainMenuChangeDelegate OnActivateSaturn;
        public event MainMenuChangeDelegate OnActivateMars;

        private DataComponent _dataComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
        }

        public void OnConstruct()
        {
            SetActivePlanet();
        }

        public void OnDestruct()
        {
            SavePlanetData();
        }

        #region Requests

        public void RequestLeftSelectionButton()
        {
            Planet activePlanet = GetSelectedPlanet();

            if (activePlanet != Planet.Mars)
                return;

            SetSelectedPlanet(Planet.Saturn);
            ChangeLeftSelectionButtonInteractable(false);
            ChangeRightSelectionButtonInteractable(true);
            ActivateSaturn();
        }

        public void RequestRightSelectionButton()
        {
            Planet activePlanet = GetSelectedPlanet();

            if (activePlanet != Planet.Saturn)
                return;

            SetSelectedPlanet(Planet.Mars);
            ChangeLeftSelectionButtonInteractable(true);
            ChangeRightSelectionButtonInteractable(false);
            ActivateMars();
        }

        #endregion

        #region Changes

        private void ChangeLeftSelectionButtonInteractable(bool isInteractable)
        {
            OnLeftSelectionButtonInteractableChange?.Invoke(isInteractable);
        }

        private void ChangeRightSelectionButtonInteractable(bool isInteractable)
        {
            OnRightSelectionButtonInteractableChange?.Invoke(isInteractable);
        }

        private Planet GetSelectedPlanet()
        {
            int selectedPlanet = _dataComponent.PlanetData.selectedPlanet;
            Planet planet = (Planet)selectedPlanet;

            return planet;
        }

        private void ActivateSaturn()
        {
            OnActivateSaturn?.Invoke();
        }

        private void ActivateMars()
        {
            OnActivateMars?.Invoke();
        }

        private void SetActivePlanet()
        {
            Planet planet = GetSelectedPlanet();

            bool isSaturnSaved = _dataComponent.InventoryData.isSaturnSaved;

            if (planet == Planet.Saturn)
            {
                ChangeLeftSelectionButtonInteractable(false);
                if (isSaturnSaved)
                    ChangeRightSelectionButtonInteractable(true);
                ActivateSaturn();
            }
            else if (planet == Planet.Mars)
            {
                ChangeLeftSelectionButtonInteractable(true);
                ChangeRightSelectionButtonInteractable(false);
                ActivateMars();
            }
        }

        #endregion

        private void SetSelectedPlanet(Planet planet)
        {
            int selectedPlaneIndex = (int)planet;

            _dataComponent.PlanetData.selectedPlanet = selectedPlaneIndex;
        }

        private void SavePlanetData()
        {
            _dataComponent.SavePlanetData();
        }
    }
}