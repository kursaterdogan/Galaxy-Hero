namespace Game
{
    using UnityEngine;
    using Base.Component;
    using Components;
    using States;

    public class MainComponent : MonoBehaviour
    {
        private ComponentContainer _componentContainer;

        private UIComponent _uiComponent;
        private IntroComponent _introComponent;

        private AppState _appState;

        private void Awake()
        {
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

        private void Update()
        {
            _appState.Update();
        }

        public void OnDestroy()
        {
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