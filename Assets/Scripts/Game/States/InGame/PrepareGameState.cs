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
            //TODO Add Provision canvas
            RequestPlayGame();
        }

        protected override void OnExit()
        {
        }

        private void RequestPlayGame()
        {
            SendTrigger((int)StateTriggers.PlayGame);
        }
    }
}