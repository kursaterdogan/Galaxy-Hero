using Base.State;
using Base.Component;
using Game.Components;
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
            //TODO Handle PrepareGameState
            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            _prepareGameComponent = componentContainer.GetComponent("PrepareGameComponent") as PrepareGameComponent;

            _prepareGameCanvas = _uiComponent.GetCanvas(UIComponent.MenuName.PrepareGame) as PrepareGameCanvas;
        }

        protected override void OnEnter()
        {
            SubscribeToComponentChangeDelegates();

            _prepareGameComponent.OnConstruct();
            _prepareGameCanvas.OnStart();

            _uiComponent.EnableCanvas(UIComponent.MenuName.PrepareGame);
        }

        protected override void OnExit()
        {
            _prepareGameComponent.OnDestruct();
            _prepareGameCanvas.OnQuit();

            UnsubscribeToComponentChangeDelegates();
        }

        public void SubscribeToComponentChangeDelegates()
        {
            _prepareGameComponent.OnLoadingComplete += RequestPlayGame;
        }

        public void UnsubscribeToComponentChangeDelegates()
        {
            _prepareGameComponent.OnLoadingComplete -= RequestPlayGame;
        }

        private void RequestPlayGame()
        {
            SendTrigger((int)StateTriggers.PlayGame);
        }
    }
}