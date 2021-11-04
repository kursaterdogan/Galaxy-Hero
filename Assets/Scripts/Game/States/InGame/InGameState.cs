namespace Game.States.InGame
{
    using Base.State;
    using UnityEngine;
    using Base.Component;
    using Components;
    using Game.UserInterfaces.InGame;

    public class InGameState : StateMachine
    {
        private UIComponent _uiComponent;
        private InGameCanvas _inGameCanvas;

        public InGameState(ComponentContainer componentContainer)
        {
            
        }

        protected override void OnEnter()
        {
            Debug.Log("InGameState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("InGameState OnExit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("InGameState Update");
        }
    }
}