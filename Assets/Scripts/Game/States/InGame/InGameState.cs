using UnityEngine;
using Base.State;
using Base.Component;
using Game.Components;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
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
    }
}