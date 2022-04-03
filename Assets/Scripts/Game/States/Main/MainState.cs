using Base.Component;
using Base.State;
using Game.Enums;

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

            AddTransition(_mainMenuState, _inventoryState, (int)StateTrigger.GoToInventory);
            AddTransition(_inventoryState, _mainMenuState, (int)StateTrigger.ReturnToMainMenu);

            AddTransition(_mainMenuState, _garageState, (int)StateTrigger.GoToGarage);
            AddTransition(_garageState, _mainMenuState, (int)StateTrigger.ReturnToMainMenu);

            AddTransition(_mainMenuState, _superPowerState, (int)StateTrigger.GoToSuperPower);
            AddTransition(_superPowerState, _mainMenuState, (int)StateTrigger.ReturnToMainMenu);

            AddTransition(_mainMenuState, _creditsState, (int)StateTrigger.GoToCredits);
            AddTransition(_creditsState, _mainMenuState, (int)StateTrigger.ReturnToMainMenu);
            
            AddTransition(_mainMenuState, _achievementState, (int)StateTrigger.GoToAchievement);
            AddTransition(_achievementState, _mainMenuState, (int)StateTrigger.ReturnToMainMenu);
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }
    }
}