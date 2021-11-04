namespace Game.Components
{
    using Base.Component;
    using Base.UserInterface;
    using UnityEngine;

    public class UIComponent : MonoBehaviour, IComponent
    {
        public enum MenuName
        {
            Splash,
            MainMenu,
        }

        [SerializeField] private BaseCanvas splashCanvas;
        [SerializeField] private BaseCanvas mainMenuCanvas;

        private BaseCanvas _activeCanvas;


        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>UIComponent initialized!</color>");
            splashCanvas.Initialize(componentContainer);
            mainMenuCanvas.Initialize(componentContainer);

            DeactivateCanvas(splashCanvas);
            DeactivateCanvas(mainMenuCanvas);
        }

        public BaseCanvas GetCanvas(MenuName canvas)
        {
            switch (canvas)
            {
                case MenuName.Splash:
                    return splashCanvas;
                case MenuName.MainMenu:
                    return mainMenuCanvas;
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
                case MenuName.Splash:
                    _activeCanvas = splashCanvas;
                    break;
                case MenuName.MainMenu:
                    _activeCanvas = mainMenuCanvas;
                    break;
            }

            if (_activeCanvas)
            {
                _activeCanvas.Activate();
            }
        }
    }
}