using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class MainMenuComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        private enum PlanetName
        {
            Saturn,
            Mars
        }

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
            PlanetName activePlanetName = GetSelectedPlanet();

            if (activePlanetName != PlanetName.Mars)
                return;

            SetSelectedPlanet(PlanetName.Saturn);
            ChangeLeftSelectionButtonInteractable(false);
            ChangeRightSelectionButtonInteractable(true);
            ActivateSaturn();
        }

        public void RequestRightSelectionButton()
        {
            PlanetName activePlanetName = GetSelectedPlanet();

            if (activePlanetName != PlanetName.Saturn)
                return;

            SetSelectedPlanet(PlanetName.Mars);
            ChangeLeftSelectionButtonInteractable(true);
            ChangeRightSelectionButtonInteractable(false);
            ActivateMars();
        }

        #endregion

        public string GetSelectedPlanetName()
        {
            return GetSelectedPlanet().ToString();
        }

        #region Changes

        private void ChangeLeftSelectionButtonInteractable(bool isInteractable)
        {
            OnLeftSelectionButtonInteractableChange?.Invoke(isInteractable);
        }

        private void ChangeRightSelectionButtonInteractable(bool isInteractable)
        {
            OnRightSelectionButtonInteractableChange?.Invoke(isInteractable);
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
            PlanetName planetName = GetSelectedPlanet();

            bool isSaturnSaved = _dataComponent.InventoryData.isSaturnSaved;

            if (planetName == PlanetName.Saturn)
            {
                ChangeLeftSelectionButtonInteractable(false);
                if (isSaturnSaved)
                    ChangeRightSelectionButtonInteractable(true);
                ActivateSaturn();
            }
            else if (planetName == PlanetName.Mars)
            {
                ChangeLeftSelectionButtonInteractable(true);
                ChangeRightSelectionButtonInteractable(false);
                ActivateMars();
            }
        }

        #endregion

        private PlanetName GetSelectedPlanet()
        {
            int selectedPlanet = _dataComponent.PlanetData.selectedPlanet;
            PlanetName planetName = (PlanetName)selectedPlanet;

            return planetName;
        }

        private void SetSelectedPlanet(PlanetName planetName)
        {
            int selectedPlaneIndex = (int)planetName;

            _dataComponent.PlanetData.selectedPlanet = selectedPlaneIndex;
        }

        private void SavePlanetData()
        {
            _dataComponent.SavePlanetData();
        }
    }
}