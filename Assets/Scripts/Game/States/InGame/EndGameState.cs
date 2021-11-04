namespace Game.States.InGame
{
    using Base.State;
    using UnityEngine;
    using Base.Component;

    public class EndGameState : StateMachine
    {
        public EndGameState(ComponentContainer componentContainer)
        {
        }

        protected override void OnEnter()
        {
            Debug.Log("EndGameState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("EndGameState OnExit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("EndGameState Update");
        }
    }
}