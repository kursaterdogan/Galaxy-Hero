using Base.Component;
using Base.State;

namespace Game.States.InGame
{
    public class GameState : StateMachine
    {
        private readonly PrepareGameState _prepareGameState;
        private readonly InGameState _inGameState;
        private readonly EndGameState _endGameState;

        public GameState(ComponentContainer componentContainer)
        {
            _prepareGameState = new PrepareGameState(componentContainer);
            _inGameState = new InGameState(componentContainer);
            _endGameState = new EndGameState(componentContainer);

            AddSubState(_prepareGameState);
            AddSubState(_inGameState);
            AddSubState(_endGameState);

            AddTransition(_prepareGameState, _inGameState, (int)StateTriggers.PlayGame);
            AddTransition(_inGameState, _endGameState, (int)StateTriggers.EndGame);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
            SetDefaultState();
        }
    }
}