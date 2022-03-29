using Base.State;
using Base.Component;
using Game.Components;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
    public class InGameState : StateMachine, IChangeable, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly InGameComponent _inGameComponent;
        private readonly InGameCanvas _inGameCanvas;

        public InGameState(ComponentContainer componentContainer)
        {
            //TODO Hande InGameState
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _inGameComponent = componentContainer.GetComponent("InGameComponent") as InGameComponent;

            _inGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.InGame) as InGameCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _inGameCanvas.OnStart();
            _inGameComponent.OnConstruct();

            _uiComponent.EnableCanvas(UIComponent.MenuName.InGame);
        }

        protected override void OnExit()
        {
            _inGameComponent.OnDestruct();

            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _inGameComponent.OnScoreChange += ChangeScore;
            _inGameComponent.OnHealthLevelChange += ChangeHealthLevel;
            _inGameComponent.OnCurrentHealthLevelChange += ChangeCurrentHealthLevel;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _inGameComponent.OnScoreChange -= ChangeScore;
            _inGameComponent.OnHealthLevelChange -= ChangeHealthLevel;
            _inGameComponent.OnCurrentHealthLevelChange -= ChangeCurrentHealthLevel;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _inGameCanvas.OnReturnToMainMenuRequest += RequestEndGame;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _inGameCanvas.OnReturnToMainMenuRequest -= RequestEndGame;
        }

        private void ChangeScore(string score)
        {
            _inGameCanvas.ChangeScore(score);
        }

        private void ChangeHealthLevel(int level)
        {
            _inGameCanvas.SetHealthLevels(level);
        }

        private void ChangeCurrentHealthLevel(int level)
        {
            _inGameCanvas.SetCurrentHealthLevel(level);
        }

        private void RequestEndGame()
        {
            SendTrigger((int)StateTriggers.EndGame);
        }
    }
}