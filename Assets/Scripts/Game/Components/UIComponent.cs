using UnityEngine;
using Base.Component;
using Base.UserInterface;
using Game.Enums;

namespace Game.Components
{
    public class UIComponent : MonoBehaviour, IComponent
    {
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

        public BaseCanvas GetCanvas(CanvasTrigger canvasTrigger)
        {
            switch (canvasTrigger)
            {
                case CanvasTrigger.Intro:
                    return introCanvas;
                case CanvasTrigger.MainMenu:
                    return mainMenuCanvas;
                case CanvasTrigger.Inventory:
                    return inventoryCanvas;
                case CanvasTrigger.Garage:
                    return garageCanvas;
                case CanvasTrigger.SuperPower:
                    return superPowerCanvas;
                case CanvasTrigger.Credits:
                    return creditsCanvas;
                case CanvasTrigger.Achievement:
                    return achievementCanvas;
                case CanvasTrigger.PrepareGame:
                    return prepareGameCanvas;
                case CanvasTrigger.InGame:
                    return inGameCanvas;
                case CanvasTrigger.EndGame:
                    return endGameCanvas;
                default:
                    return null;
            }
        }

        public void EnableCanvas(CanvasTrigger canvasTrigger)
        {
            DeactivateCanvas(_activeCanvas);
            ActivateCanvas(canvasTrigger);
        }

        private void DeactivateCanvas(BaseCanvas canvas)
        {
            if (canvas)
                canvas.Deactivate();
        }

        private void ActivateCanvas(CanvasTrigger canvasTrigger)
        {
            switch (canvasTrigger)
            {
                case CanvasTrigger.Intro:
                    _activeCanvas = introCanvas;
                    break;
                case CanvasTrigger.MainMenu:
                    _activeCanvas = mainMenuCanvas;
                    break;
                case CanvasTrigger.Inventory:
                    _activeCanvas = inventoryCanvas;
                    break;
                case CanvasTrigger.Garage:
                    _activeCanvas = garageCanvas;
                    break;
                case CanvasTrigger.SuperPower:
                    _activeCanvas = superPowerCanvas;
                    break;
                case CanvasTrigger.Credits:
                    _activeCanvas = creditsCanvas;
                    break;
                case CanvasTrigger.Achievement:
                    _activeCanvas = achievementCanvas;
                    break;
                case CanvasTrigger.PrepareGame:
                    _activeCanvas = prepareGameCanvas;
                    break;
                case CanvasTrigger.InGame:
                    _activeCanvas = inGameCanvas;
                    break;
                case CanvasTrigger.EndGame:
                    _activeCanvas = endGameCanvas;
                    break;
            }

            if (_activeCanvas)
                _activeCanvas.Activate();
        }
    }
}