using Base.Component;
using Base.State;

namespace Game.States.Splash
{
    public class SplashState : StateMachine
    {
        private readonly IntroState _introState;

        public SplashState(ComponentContainer componentContainer)
        {
            _introState = new IntroState(componentContainer);

            AddSubState(_introState);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }
    }
}