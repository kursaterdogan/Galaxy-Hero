using Base.Component;
using Base.State;

namespace Game.States.Main
{
    public class MainState : StateMachine
    {
        private readonly MainMenuState _mainMenuState;
        private readonly InventoryState _inventoryState;
        private readonly GarageState _garageState;
        private readonly SuperPowerState _superPowerState;
        private readonly CreditsState _creditsState;
        private readonly AchievementState _achievementState;

        public MainState(ComponentContainer componentContainer)
        {
            _mainMenuState = new MainMenuState(componentContainer);
            _inventoryState = new InventoryState(componentContainer);
            _garageState = new GarageState(componentContainer);
            _superPowerState = new SuperPowerState(componentContainer);
            _creditsState = new CreditsState(componentContainer);
            _achievementState = new AchievementState(componentContainer);

            AddSubState(_mainMenuState);
            AddSubState(_inventoryState);
            AddSubState(_garageState);
            AddSubState(_superPowerState);
            AddSubState(_creditsState);
            AddSubState(_achievementState);

            AddTransition(_mainMenuState, _inventoryState, (int)StateTriggers.GoToInventory);
            AddTransition(_inventoryState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);

            AddTransition(_mainMenuState, _garageState, (int)StateTriggers.GoToGarage);
            AddTransition(_garageState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);

            AddTransition(_mainMenuState, _superPowerState, (int)StateTriggers.GoToSuperPower);
            AddTransition(_superPowerState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);

            AddTransition(_mainMenuState, _creditsState, (int)StateTriggers.GoToCredits);
            AddTransition(_creditsState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);
            
            AddTransition(_mainMenuState, _achievementState, (int)StateTriggers.GoToAchievement);
            AddTransition(_achievementState, _mainMenuState, (int)StateTriggers.ReturnToMainMenu);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }
    }
}