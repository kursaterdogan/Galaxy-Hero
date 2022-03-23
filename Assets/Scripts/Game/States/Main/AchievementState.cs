using Base.Component;
using Base.State;
using Game.Components;
using Game.UserInterfaces.Main;

namespace Game.States.Main
{
    public class AchievementState : StateMachine, IRequestable, IChangeable
    {
        private readonly UIComponent _uiComponent;
        private readonly AchievementComponent _achievementComponent;

        private readonly AchievementCanvas _achievementCanvas;

        public AchievementState(ComponentContainer componentContainer)
        {
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _achievementComponent = componentContainer.GetComponent("AchievementComponent") as AchievementComponent;

            _achievementCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.Achievement) as AchievementCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _achievementComponent.OnConstruct();

            _uiComponent.EnableCanvas(UIComponent.MenuName.Achievement);
        }

        protected override void OnExit()
        {
            _achievementComponent.OnDestruct();

            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _achievementComponent.OnHighScoreChange += ChangeHighScore;
            _achievementComponent.OnNeedHelpActivate += ActivateNeedHelpText;
            _achievementComponent.OnOCaptainMyCaptainActivate += ActivateOCaptainMyCaptainText;
            _achievementComponent.OnNeedHelpDeactivate += DeactivateNeedHelpText;
            _achievementComponent.OnOCaptainMyCaptainDeactivate += DeactivateOCaptainMyCaptainText;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _achievementComponent.OnHighScoreChange -= ChangeHighScore;
            _achievementComponent.OnNeedHelpActivate -= ActivateNeedHelpText;
            _achievementComponent.OnOCaptainMyCaptainActivate -= ActivateOCaptainMyCaptainText;
            _achievementComponent.OnNeedHelpDeactivate -= DeactivateNeedHelpText;
            _achievementComponent.OnOCaptainMyCaptainDeactivate -= DeactivateOCaptainMyCaptainText;
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _achievementCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _achievementCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        #region Changes

        private void ChangeHighScore(string highScore)
        {
            _achievementCanvas.ChangeHighScore(highScore);
        }

        private void ActivateNeedHelpText()
        {
            _achievementCanvas.ActivateNeedHelpText();
        }

        private void ActivateOCaptainMyCaptainText()
        {
            _achievementCanvas.ActivateOCaptainMyCaptainText();
        }

        private void DeactivateNeedHelpText()
        {
            _achievementCanvas.DeactivateNeedHelpText();
        }

        private void DeactivateOCaptainMyCaptainText()
        {
            _achievementCanvas.DeactivateOCaptainMyCaptainText();
        }

        #endregion

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}