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
        private MainMenuComponent _mainMenuComponent;
        private InventoryComponent _inventoryComponent;
        private GarageComponent _garageComponent;
        private SuperPowerComponent _superPowerComponent;
        private CreditsComponent _creditsComponent;
        private AchievementComponent _achievementComponent;
        private PrepareGameComponent _prepareGameComponent;
        private InGameComponent _inGameComponent;
        private EndGameComponent _endGameComponent;

        private AppState _appState;

        void Awake()
        {
            Debug.Log("<color=lime>" + GetType().Name + " initialized!</color>");

            CreateComponentContainer();
        }

        void Start()
        {
            CreateDataComponent();
            CreateUIComponent();
            CreateIntroComponent();
            CreateMainMenuComponent();
            CreateInventoryComponent();
            CreateGarageComponent();
            CreateSuperPowerComponent();
            CreateCreditsComponent();
            CreateAchievementComponent();
            CreatePrepareGameComponent();
            CreateInGameComponent();
            CreateEndGameComponent();

            InitializeComponents();
            CreateAppState();
            EnterAppState();
        }

        private void CreateComponentContainer()
        {
            _componentContainer = new ComponentContainer();
        }

        private void InitializeComponents()
        {
            _dataComponent.Initialize(_componentContainer);
            _uiComponent.Initialize(_componentContainer);
            _introComponent.Initialize(_componentContainer);
            _mainMenuComponent.Initialize(_componentContainer);
            _inventoryComponent.Initialize(_componentContainer);
            _garageComponent.Initialize(_componentContainer);
            _superPowerComponent.Initialize(_componentContainer);
            _creditsComponent.Initialize(_componentContainer);
            _achievementComponent.Initialize(_componentContainer);
            _prepareGameComponent.Initialize(_componentContainer);
            _inGameComponent.Initialize(_componentContainer);
            _endGameComponent.Initialize(_componentContainer);
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

        private void CreateMainMenuComponent()
        {
            _mainMenuComponent = FindObjectOfType<MainMenuComponent>();
            string componentKey = _mainMenuComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _mainMenuComponent);
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

        private void CreateAchievementComponent()
        {
            _achievementComponent = FindObjectOfType<AchievementComponent>();
            string componentKey = _achievementComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _achievementComponent);
        }

        private void CreatePrepareGameComponent()
        {
            _prepareGameComponent = FindObjectOfType<PrepareGameComponent>();
            string componentKey = _prepareGameComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _prepareGameComponent);
        }

        private void CreateInGameComponent()
        {
            _inGameComponent = FindObjectOfType<InGameComponent>();
            string componentKey = _inGameComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _inGameComponent);
        }

        private void CreateEndGameComponent()
        {
            _endGameComponent = FindObjectOfType<EndGameComponent>();
            string componentKey = _endGameComponent.GetType().Name;

            _componentContainer.AddComponent(componentKey, _endGameComponent);
        }

        private void CreateAppState()
        {
            _appState = new AppState(_componentContainer);
        }

        private void EnterAppState()
        {
            _appState.Enter();
        }
    }
}