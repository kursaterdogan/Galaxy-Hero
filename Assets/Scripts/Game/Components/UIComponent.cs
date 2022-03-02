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
            InGame
        }

        [SerializeField] private BaseCanvas introCanvas;
        [SerializeField] private BaseCanvas mainMenuCanvas;
        [SerializeField] private BaseCanvas inventoryCanvas;
        [SerializeField] private BaseCanvas garageCanvas;
        [SerializeField] private BaseCanvas inGameCanvas;

        private BaseCanvas _activeCanvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>UIComponent initialized!</color>");

            introCanvas.Initialize();
            mainMenuCanvas.Initialize();
            inventoryCanvas.Initialize();
            garageCanvas.Initialize();
            inGameCanvas.Initialize();

            DeactivateCanvas(introCanvas);
            DeactivateCanvas(mainMenuCanvas);
            DeactivateCanvas(inventoryCanvas);
            DeactivateCanvas(garageCanvas);
            DeactivateCanvas(inGameCanvas);
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
                case MenuName.InGame:
                    return inGameCanvas;
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
            {
                canvas.Deactivate();
            }
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
                case MenuName.InGame:
                    _activeCanvas = inGameCanvas;
                    break;
            }

            if (_activeCanvas)
            {
                _activeCanvas.Activate();
            }
        }
    }
}