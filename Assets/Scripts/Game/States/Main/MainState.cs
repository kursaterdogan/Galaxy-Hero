namespace Game.States.Main
{
    using Base.Component;
    using Base.State;
    using UnityEngine;

    public class MainState : StateMachine
    {
        private MainMenuState _mainMenuState;

        public MainState(ComponentContainer componentContainer)
        {
            _mainMenuState = new MainMenuState(componentContainer);

            AddSubState(_mainMenuState);
        }

        protected override void OnEnter()
        {
            Debug.Log("MainState OnEnter");
            SetDefaultState();
        }

        protected override void OnExit()
        {
            Debug.Log("MainState OnExit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("MainState OnUpdate");
        }
    }
}