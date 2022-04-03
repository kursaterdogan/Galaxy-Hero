using Base.Component;
using Base.State;
using Game.Enums;

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

            AddTransition(_prepareGameState, _inGameState, (int)StateTrigger.PlayGame);
            AddTransition(_inGameState, _endGameState, (int)StateTrigger.EndGame);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
            SetCurrentSubStateToDefaultSubState();
        }
    }
}