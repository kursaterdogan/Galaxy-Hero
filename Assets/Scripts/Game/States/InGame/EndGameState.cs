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
            //TODO Handle EndGameState
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _endGameComponent = componentContainer.GetComponent("EndGameComponent") as EndGameComponent;

            _endGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.EndGame) as EndGameCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();
            SubscribeToCanvasRequestDelegates();

            _uiComponent.EnableCanvas(UIComponent.MenuName.EndGame);
        }

        protected override void OnExit()
        {
            UnsubscribeToComponentChangeDelegates();
            UnsubscribeToCanvasRequestDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
        }

        public void SubscribeToCanvasRequestDelegates()
        {
            _endGameCanvas.OnReturnToMainMenuRequest += RequestReturnToMainMenu;
        }

        public void UnsubscribeToCanvasRequestDelegates()
        {
            _endGameCanvas.OnReturnToMainMenuRequest -= RequestReturnToMainMenu;
        }

        private void RequestReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.ReturnToMainMenu);
        }
    }
}