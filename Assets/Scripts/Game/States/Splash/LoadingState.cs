using UnityEngine;
using Base.State;

namespace Game.States.Splash
{
    public class LoadingState : StateMachine
    {
        private const float FakeLoadingTime = 1f;
        private float _time;

        protected override void OnEnter()
        {
            Debug.Log("LoadingState OnEnter");
        }

        protected override void OnUpdate()
        {
            Debug.Log("LoadingState OnUpdate");

            _time += Time.deltaTime;
            if (_time > FakeLoadingTime)
            {
                SendTrigger((int)StateTriggers.SplashCompleted);
            }
        }

        protected override void OnExit()
        {
            Debug.Log("LoadingState OnExit");
        }
    }
}