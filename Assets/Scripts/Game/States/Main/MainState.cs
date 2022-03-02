using UnityEngine;
using Base.Component;
using Base.State;

namespace Game.States.Main
{
    public class MainState : StateMachine
    {
        private MainMenuState _mainMenuState;
        private InventoryState _inventoryState;
        private GarageState _garageState;

        public MainState(ComponentContainer componentContainer)
        {
            _mainMenuState = new MainMenuState(componentContainer);
            _inventoryState = new InventoryState(componentContainer);
            _garageState = new GarageState(componentContainer);

            AddSubState(_mainMenuState);
            AddSubState(_inventoryState);
            AddSubState(_garageState);

            AddTransition(_mainMenuState, _inventoryState, (int)StateTriggers.GoToInventory);
            AddTransition(_inventoryState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);

            AddTransition(_mainMenuState, _garageState, (int)StateTriggers.GoToGarage);
            AddTransition(_garageState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);
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