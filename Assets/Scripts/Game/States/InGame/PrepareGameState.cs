using UnityEngine;
using Base.State;
using Base.Component;

namespace Game.States.InGame
{
    public class PrepareGameState : StateMachine
    {
        public PrepareGameState(ComponentContainer componentContainer)
        {
            //TODO Hande PrepareGameState
        }

        protected override void OnEnter()
        {
            Debug.Log("<color=orange>PrepareGameState OnEnter</color>");
            //TODO Add Provision canvas
            RequestPlayGame();
        }

        protected override void OnExit()
        {
            Debug.Log("<color=cyan>PrepareGameState OnExit</color>");
        }

        private void RequestPlayGame()
        {
            SendTrigger((int)StateTriggers.PlayGame);
        }
    }
}