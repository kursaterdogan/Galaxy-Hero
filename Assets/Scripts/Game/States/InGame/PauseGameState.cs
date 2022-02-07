using UnityEngine;
using Base.State;
using Base.Component;

namespace Game.States.InGame
{
    public class PauseGameState : StateMachine
    {
        public PauseGameState(ComponentContainer componentContainer)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("PauseGameState OnEnter");
        }

        protected override void OnUpdate()
        {
            Debug.Log("PauseGameState Update");
        }

        protected override void OnExit()
        {
            Debug.Log("PauseGameState OnExit");
        }
    }
}