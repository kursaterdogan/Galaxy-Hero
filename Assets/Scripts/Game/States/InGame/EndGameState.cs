using Base.State;
using Base.Component;
using Game.Components;
using Game.UserInterfaces.InGame;

namespace Game.States.InGame
{
    public class EndGameState : StateMachine, IChangeable, IRequestable
    {
        private readonly UIComponent _uiComponent;
        private readonly EndGameComponent _endGameComponent;

        private readonly EndGameCanvas _endGameCanvas;

        public EndGameState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _endGameComponent = componentContainer.GetComponent("EndGameComponent") as EndGameComponent;

            _endGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.EndGame) as EndGameCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _endGameCanvas.OnStart();
            _endGameComponent.OnConstruct();

            _uiComponent.EnableCanvas(UIComponent.MenuName.EndGame);
        }

        protected override void OnExit()
        {
            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _endGameComponent.OnWin += Win;
            _endGameComponent.OnLose += Lose;
            _endGameComponent.OnSavePlanetChange += ChangeSavePlanetText;
            _endGameComponent.OnNeedYourHelpChange += ChangeNeedYourHelpText;
            _endGameComponent.OnScoreChange += ChangeScore;
            _endGameComponent.OnGoldChange += ChangeGold;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _endGameComponent.OnWin -= Win;
            _endGameComponent.OnLose -= Lose;
            _endGameComponent.OnSavePlanetChange -= ChangeSavePlanetText;
            _endGameComponent.OnNeedYourHelpChange -= ChangeNeedYourHelpText;
            _endGameComponent.OnScoreChange -= ChangeScore;
            _endGameComponent.OnGoldChange -= ChangeGold;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _endGameCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _endGameCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        #region Changes

        private void Win()
        {
            _endGameCanvas.EnableWinObjects();
        }

        private void Lose()
        {
            _endGameCanvas.EnableLoseObjects();
        }

        private void ChangeSavePlanetText(string savePlanet)
        {
            _endGameCanvas.ChangeSavePlanetText(savePlanet);
        }

        private void ChangeNeedYourHelpText(string needYourHelp)
        {
            _endGameCanvas.ChangeNeedYourHelpText(needYourHelp);
        }

        private void ChangeScore(string score, string scoreAmount)
        {
            _endGameCanvas.ChangeScore(score, scoreAmount);
        }

        private void ChangeGold(string ownedCoin, string lastGainedCoin)
        {
            _endGameCanvas.ChangeGold(ownedCoin, lastGainedCoin);
        }

        #endregion

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}