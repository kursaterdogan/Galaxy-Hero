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
        private SplashComponent _splashComponent;
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
            CreateSplashComponent();
            CreateGameplayComponent();

            InitializeComponents();
            CreateAppState();
            _appState.Enter();
        }

        private void InitializeComponents()
        {
            //TODO Initialize Components
            _uiComponent.Initialize(_componentContainer);
            _splashComponent.Initialize(_componentContainer);
            _gameplayComponent.Initialize(_componentContainer);
        }

        private void CreateUIComponent()
        {
            _uiComponent = FindObjectOfType<UIComponent>();
            _componentContainer.AddComponent("UIComponent", _uiComponent);
        }

        private void CreateSplashComponent()
        {
            _splashComponent = FindObjectOfType<SplashComponent>();
            _componentContainer.AddComponent("SplashComponent", _splashComponent);
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