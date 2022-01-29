namespace Game.States.InGame
{
    using Base.State;
    using UnityEngine;
    using Base.Component;

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