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
            InGame
        }

        [SerializeField] private BaseCanvas introCanvas;
        [SerializeField] private BaseCanvas mainMenuCanvas;
        [SerializeField] private BaseCanvas inGameCanvas;

        private BaseCanvas _activeCanvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>UIComponent initialized!</color>");

            introCanvas.Initialize(componentContainer);
            mainMenuCanvas.Initialize(componentContainer);
            inGameCanvas.Initialize(componentContainer);

            DeactivateCanvas(introCanvas);
            DeactivateCanvas(mainMenuCanvas);
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