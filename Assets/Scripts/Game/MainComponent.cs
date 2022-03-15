using UnityEngine;
using Base.Component;
using Game.Components;
using Game.States;

namespace Game
{
    public class MainComponent : MonoBehaviour
    {
        private ComponentContainer _componentContainer;

        private DataComponent _dataComponent;
        private UIComponent _uiComponent;
        private IntroComponent _introComponent;
        private InventoryComponent _inventoryComponent;
        private GarageComponent _garageComponent;
        private SuperPowerComponent _superPowerComponent;
        private CreditsComponent _creditsComponent;
        private GameplayComponent _gameplayComponent;

        private AppState _appState;

        void Awake()
        {
            Debug.Log("<color=lime>" + GetType().Name + " initialized!</color>");

            _componentContainer = new ComponentContainer();
        }

        void Start()
        {
            //TODO Create Components
            CreateDataComponent();
            CreateUIComponent();
            CreateIntroComponent();
            CreateInventoryComponent();
            CreateGarageComponent();
            CreateSuperPowerComponent();
            CreateCreditsComponent();
            CreateGameplayComponent();

            InitializeComponents();
            CreateAppState();
            _appState.Enter();
        }

        private void InitializeComponents()
        {
            //TODO Initialize Components & Refactor Need componentContainer?
            _dataComponent.Initialize(_componentContainer);
            _uiComponent.Initialize(_componentContainer);
            _introComponent.Initialize(_componentContainer);
            _inventoryComponent.Initialize(_componentContainer);
            _garageComponent.Initialize(_componentContainer);
            _superPowerComponent.Initialize(_componentContainer);
            _creditsComponent.Initialize(_componentContainer);
            _gameplayComponent.Initialize(_componentContainer);
        }

        private void CreateDataComponent()
        {
            _dataComponent = FindObjectOfType<DataComponent>();
            string componentKey = _dataComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _dataComponent);
        }

        private void CreateUIComponent()
        {
            _uiComponent = FindObjectOfType<UIComponent>();
            string componentKey = _uiComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _uiComponent);
        }

        private void CreateIntroComponent()
        {
            _introComponent = FindObjectOfType<IntroComponent>();
            string componentKey = _introComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _introComponent);
        }

        private void CreateInventoryComponent()
        {
            _inventoryComponent = FindObjectOfType<InventoryComponent>();
            string componentKey = _inventoryComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _inventoryComponent);
        }

        private void CreateGarageComponent()
        {
            _garageComponent = FindObjectOfType<GarageComponent>();
            string componentKey = _garageComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _garageComponent);
        }

        private void CreateSuperPowerComponent()
        {
            _superPowerComponent = FindObjectOfType<SuperPowerComponent>();
            string componentKey = _superPowerComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _superPowerComponent);
        }

        private void CreateCreditsComponent()
        {
            _creditsComponent = FindObjectOfType<CreditsComponent>();
            string componentKey = _creditsComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _creditsComponent);
        }

        private void CreateGameplayComponent()
        {
            _gameplayComponent = FindObjectOfType<GameplayComponent>();
            string componentKey = _gameplayComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _gameplayComponent);
        }

        private void CreateAppState()
        {
            _appState = new AppState(_componentContainer);
        }
    }
}