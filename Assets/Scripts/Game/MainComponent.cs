using UnityEngine;
using Base.Component;
using Game.Components;
using Game.States;

namespace Game
{
    public class MainComponent : MonoBehaviour
    {
        private ComponentContainer _componentContainer;

        private UIComponent _uiComponent;
        private IntroComponent _introComponent;
        private GameplayComponent _gameplayComponent;

        private AppState _appState;

        void Awake()
        {
            Debug.Log("<color=green>MainComponent initialized!</color>");
            _componentContainer = new ComponentContainer();
        }

        void Start()
        {
            //TODO Create Components
            CreateUIComponent();
            CreateIntroComponent();
            CreateGameplayComponent();

            InitializeComponents();
            CreateAppState();
            _appState.Enter();
        }

        private void InitializeComponents()
        {
            //TODO Initialize Components
            _uiComponent.Initialize(_componentContainer);
            _introComponent.Initialize(_componentContainer);
            _gameplayComponent.Initialize(_componentContainer);
        }

        private void CreateUIComponent()
        {
            _uiComponent = FindObjectOfType<UIComponent>();
            _componentContainer.AddComponent("UIComponent", _uiComponent);
        }

        private void CreateIntroComponent()
        {
            _introComponent = FindObjectOfType<IntroComponent>();
            _componentContainer.AddComponent("IntroComponent", _introComponent);
        }

        private void CreateGameplayComponent()
        {
            _gameplayComponent = FindObjectOfType<GameplayComponent>();
            _componentContainer.AddComponent("GameplayComponent", _gameplayComponent);
        }

        private void CreateAppState()
        {
            _appState = new AppState(_componentContainer);
        }
    }
}