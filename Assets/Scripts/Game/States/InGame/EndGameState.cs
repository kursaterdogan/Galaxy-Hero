using UnityEngine;
using Base.State;
using Base.Component;

namespace Game.States.InGame
{
    public class EndGameState : StateMachine
    {
        public EndGameState(ComponentContainer componentContainer)
        {
            //TODO Hande EndGameState
        }

        protected override void OnEnter()
        {
            Debug.Log("<color=orange>EndGameState OnEnter</color>");
        }

        protected override void OnExit()
        {
            Debug.Log("<color=cyan>EndGameState OnExit</color>");
        }
    }
}