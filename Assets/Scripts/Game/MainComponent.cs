using System;

namespace Game
{
    using UnityEngine;
    using Base.Component;
    using States;

    public class MainComponent : MonoBehaviour
    {
        private ComponentContainer _componentContainer;

        private AppState _appState;

        private void Awake()
        {
            _componentContainer = new ComponentContainer();
        }

        private void Start()
        {
            //TODO Create Components
            //TODO Create State
            InitializeComponents();
        }

        private void Update()
        {
            //TODO appState.Update
        }

        private void InitializeComponents()
        {
            //TODO Initialize Components
        }

        private void CreateAppState()
        {
            _appState = new AppState(_componentContainer);
        }
    }
}