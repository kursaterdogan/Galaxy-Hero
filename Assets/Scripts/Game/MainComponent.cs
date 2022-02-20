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

        private AppState _appState;

        private void Awake()
        {
            Debug.Log("<color=green>MainComponent initialized!</color>");
            _componentContainer = new ComponentContainer();
        }

        private void Start()
        {
            //TODO Create Components
            CreateUIComponent();
            CreateIntroComponent();

            InitializeComponents();
            CreateAppState();
            _appState.Enter();
        }

        private void InitializeComponents()
        {
            //TODO Initialize Components
            _uiComponent.Initialize(_componentContainer);
            _introComponent.Initialize(_componentContainer);
        }

        private void CreateUIComponent()
        {
            _introComponent = FindObjectOfType<IntroComponent>();
            _componentContainer.AddComponent("IntroComponent", _introComponent);
        }

        private void CreateIntroComponent()
        {
            _uiComponent = FindObjectOfType<UIComponent>();
            _componentContainer.AddComponent("UIComponent", _uiComponent);
        }

        private void CreateAppState()
        {
            _appState = new AppState(_componentContainer);
        }
    }
}