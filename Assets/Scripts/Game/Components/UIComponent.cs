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

        private BaseCanvas _activeCanvas;


        public void Initialize(ComponentContainer componentContainer)
        {
            splashCanvas.Initialize(componentContainer);

            DeactivateCanvas(splashCanvas);
        }

        public BaseCanvas GetCanvas(MenuName canvas)
        {
            switch (canvas)
            {
                case MenuName.Splash:
                    return splashCanvas;
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
            }

            if (_activeCanvas)
            {
                _activeCanvas.Activate();
            }
        }
    }
}