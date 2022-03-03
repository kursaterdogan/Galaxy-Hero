using Base.Component;
using Base.State;

namespace Game.States.Main
{
    public class MainState : StateMachine
    {
        private MainMenuState _mainMenuState;
        private InventoryState _inventoryState;
        private GarageState _garageState;
        private SuperPowerState _superPowerState;

        public MainState(ComponentContainer componentContainer)
        {
            _mainMenuState = new MainMenuState(componentContainer);
            _inventoryState = new InventoryState(componentContainer);
            _garageState = new GarageState(componentContainer);
            _superPowerState = new SuperPowerState(componentContainer);

            AddSubState(_mainMenuState);
            AddSubState(_inventoryState);
            AddSubState(_garageState);
            AddSubState(_superPowerState);

            AddTransition(_mainMenuState, _inventoryState, (int)StateTriggers.GoToInventory);
            AddTransition(_inventoryState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);

            AddTransition(_mainMenuState, _garageState, (int)StateTriggers.GoToGarage);
            AddTransition(_garageState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);

            AddTransition(_mainMenuState, _superPowerState, (int)StateTriggers.GoToSuperPower);
            AddTransition(_superPowerState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }
    }
}