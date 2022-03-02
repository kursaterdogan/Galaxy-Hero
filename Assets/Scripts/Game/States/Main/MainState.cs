using UnityEngine;
using Base.Component;
using Base.State;

namespace Game.States.Main
{
    public class MainState : StateMachine
    {
        private MainMenuState _mainMenuState;
        private InventoryState _inventoryState;

        public MainState(ComponentContainer componentContainer)
        {
            _mainMenuState = new MainMenuState(componentContainer);
            _inventoryState = new InventoryState(componentContainer);

            AddSubState(_mainMenuState);
            AddSubState(_inventoryState);

            AddTransition(_mainMenuState, _inventoryState, (int)StateTriggers.GoToInventory);
            AddTransition(_inventoryState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);
        }

        protected override void OnEnter()
        {
            Debug.Log("MainState OnEnter");
        }

        protected override void OnExit()
        {
            Debug.Log("MainState OnExit");
        }
    }
}