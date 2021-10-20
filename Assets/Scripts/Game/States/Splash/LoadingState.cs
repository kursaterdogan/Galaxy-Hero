namespace Game.States.Splash
{
    using Base.State;
    using UnityEngine;

    public class LoadingState : StateMachine
    {
        protected override void OnEnter()
        {
            Debug.Log("Loading State On Enter");
        }

        protected override void OnExit()
        {
            Debug.Log("Loading State On Exit");
        }

        protected override void OnUpdate()
        {
            Debug.Log("Loading State On Update");
        }
    }
}