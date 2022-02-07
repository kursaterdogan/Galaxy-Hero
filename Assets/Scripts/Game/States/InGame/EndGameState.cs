using UnityEngine;
using Base.State;
using Base.Component;

namespace Game.States.InGame
{
    public class EndGameState : StateMachine
    {
        public EndGameState(ComponentContainer componentContainer)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("EndGameState OnEnter");
        }

        protected override void OnUpdate()
        {
            Debug.Log("EndGameState Update");
        }

        protected override void OnExit()
        {
            Debug.Log("EndGameState OnExit");
        }
    }
}