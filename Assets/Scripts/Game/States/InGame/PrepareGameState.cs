namespace Game.States.InGame
{
    using Base.State;
    using UnityEngine;
    using Base.Component;

    public class PrepareGameState : StateMachine
    {
        public PrepareGameState(ComponentContainer componentContainer)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("PrepareGameState OnEnter");
            //TODO Add Provision canvas
            RequestInGame();
        }

        protected override void OnUpdate()
        {
            Debug.Log("PrepareGameState Update");
        }

        protected override void OnExit()
        {
            Debug.Log("PrepareGameState OnExit");
        }

        private void RequestInGame()
        {
            SendTrigger((int)StateTriggers.PlayGameRequest);
        }

        private void RequestPause()
        {
            SendTrigger((int)StateTriggers.PauseGameRequest);
        }
    }
}