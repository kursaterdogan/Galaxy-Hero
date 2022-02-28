using UnityEngine;
using Base.State;
using Base.Component;

namespace Game.States.InGame
{
    public class PrepareGameState : StateMachine
    {
        public PrepareGameState(ComponentContainer componentContainer)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("PrepareGameState OnEnter");
            //TODO Add Provision canvas
            RequestPlayGame();
        }

        protected override void OnExit()
        {
            Debug.Log("PrepareGameState OnExit");
        }

        private void RequestPlayGame()
        {
            SendTrigger((int)StateTriggers.PlayGame);
        }
    }
}