namespace Game.States.Splash
{
    using Base.State;
    using UnityEngine;

    public class LoadingState : StateMachine
    {
        private const float FakeLoadingTime = 1f;
        private float _time;

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
            _time += Time.deltaTime;

            if (_time > FakeLoadingTime)
            {
                SendTrigger((int)StateTriggers.SplashCompleted);
            }
        }
    }
}