using Base.State;
using Base.Component;
using Game.Components;
using Game.Enums;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
    public class PrepareGameState : StateMachine, IChangeable
    {
        private readonly UIComponent _uiComponent;
        private readonly PrepareGameComponent _prepareGameComponent;

        private readonly PrepareGameCanvas _prepareGameCanvas;

        public PrepareGameState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _prepareGameComponent = componentContainer.GetComponent("PrepareGameComponent") as PrepareGameComponent;

            _prepareGameCanvas = _uiComponent.GetCanvas(CanvasTrigger.PrepareGame) as PrepareGameCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();

            _prepareGameComponent.OnConstruct();
            _prepareGameCanvas.OnStart();

            _uiComponent.EnableCanvas(CanvasTrigger.PrepareGame);
        }

        protected override void OnExit()
        {
            _prepareGameComponent.OnDestruct();
            _prepareGameCanvas.OnQuit();

            UnsubscribeToComponentChangeDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _prepareGameComponent.OnHighScoreChange += ChangeHighScore;
            _prepareGameComponent.OnSuperPowerChange += ChangeSuperPower;
            _prepareGameComponent.OnLoadingComplete += RequestPlayGame;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _prepareGameComponent.OnHighScoreChange -= ChangeHighScore;
            _prepareGameComponent.OnSuperPowerChange -= ChangeSuperPower;
            _prepareGameComponent.OnLoadingComplete -= RequestPlayGame;
        }

        #region Changes

        private void ChangeHighScore(string highScore)
        {
            _prepareGameCanvas.SetHighScoreText(highScore);
        }

        private void ChangeSuperPower(string selectedSuperPower)
        {
            _prepareGameCanvas.SetSelectedSuperPowerText(selectedSuperPower);
        }

        private void RequestPlayGame()
        {
            SendTrigger((int)StateTrigger.PlayGame);
        }

        #endregion
    }
}