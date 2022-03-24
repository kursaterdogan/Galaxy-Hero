using UnityEngine;
using Base.Component;
using Base.UserInterface;

namespace Game.Components
{
    public class UIComponent : MonoBehaviour, IComponent
    {
        public enum MenuName
        {
            Intro,
            MainMenu,
            Inventory,
            Garage,
            SuperPower,
            Credits,
            Achievement,
            PrepareGame,
            InGame,
            EndGame
        }

        [SerializeField] private BaseCanvas introCanvas;
        [SerializeField] private BaseCanvas mainMenuCanvas;
        [SerializeField] private BaseCanvas inventoryCanvas;
        [SerializeField] private BaseCanvas garageCanvas;
        [SerializeField] private BaseCanvas superPowerCanvas;
        [SerializeField] private BaseCanvas creditsCanvas;
        [SerializeField] private BaseCanvas achievementCanvas;
        [SerializeField] private BaseCanvas prepareGameCanvas;
        [SerializeField] private BaseCanvas inGameCanvas;
        [SerializeField] private BaseCanvas endGameCanvas;

        private BaseCanvas _activeCanvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            introCanvas.Initialize();
            mainMenuCanvas.Initialize();
            inventoryCanvas.Initialize();
            garageCanvas.Initialize();
            superPowerCanvas.Initialize();
            creditsCanvas.Initialize();
            achievementCanvas.Initialize();
            prepareGameCanvas.Initialize();
            inGameCanvas.Initialize();
            endGameCanvas.Initialize();

            DeactivateCanvas(introCanvas);
            DeactivateCanvas(mainMenuCanvas);
            DeactivateCanvas(inventoryCanvas);
            DeactivateCanvas(garageCanvas);
            DeactivateCanvas(superPowerCanvas);
            DeactivateCanvas(creditsCanvas);
            DeactivateCanvas(achievementCanvas);
            DeactivateCanvas(prepareGameCanvas);
            DeactivateCanvas(inGameCanvas);
            DeactivateCanvas(endGameCanvas);
        }

        public BaseCanvas GetCanvas(MenuName canvas)
        {
            switch (canvas)
            {
                case MenuName.Intro:
                    return introCanvas;
                case MenuName.MainMenu:
                    return mainMenuCanvas;
                case MenuName.Inventory:
                    return inventoryCanvas;
                case MenuName.Garage:
                    return garageCanvas;
                case MenuName.SuperPower:
                    return superPowerCanvas;
                case MenuName.Credits:
                    return creditsCanvas;
                case MenuName.Achievement:
                    return achievementCanvas;
                case MenuName.PrepareGame:
                    return prepareGameCanvas;
                case MenuName.InGame:
                    return inGameCanvas;
                case MenuName.EndGame:
                    return endGameCanvas;
                default:
                    return null;
            }
        }

        public void EnableCanvas(MenuName menuName)
        {
            DeactivateCanvas(_activeCanvas);
            ActivateCanvas(menuName);
        }

        private void DeactivateCanvas(BaseCanvas canvas)
        {
            if (canvas)
                canvas.Deactivate();
        }

        private void ActivateCanvas(MenuName menuName)
        {
            switch (menuName)
            {
                case MenuName.Intro:
                    _activeCanvas = introCanvas;
                    break;
                case MenuName.MainMenu:
                    _activeCanvas = mainMenuCanvas;
                    break;
                case MenuName.Inventory:
                    _activeCanvas = inventoryCanvas;
                    break;
                case MenuName.Garage:
                    _activeCanvas = garageCanvas;
                    break;
                case MenuName.SuperPower:
                    _activeCanvas = superPowerCanvas;
                    break;
                case MenuName.Credits:
                    _activeCanvas = creditsCanvas;
                    break;
                case MenuName.Achievement:
                    _activeCanvas = achievementCanvas;
                    break;
                case MenuName.PrepareGame:
                    _activeCanvas = prepareGameCanvas;
                    break;
                case MenuName.InGame:
                    _activeCanvas = inGameCanvas;
                    break;
                case MenuName.EndGame:
                    _activeCanvas = endGameCanvas;
                    break;
            }

            if (_activeCanvas)
                _activeCanvas.Activate();
        }
    }
}