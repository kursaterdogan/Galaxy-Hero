namespace Base.UserInterface
{
    using Component;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Canvas))]
    public abstract class BaseCanvas : MonoBehaviour
    {
        public delegate void ReturnToMainMenuDelegate();

        public event ReturnToMainMenuDelegate OnReturnToMainMenu;

        private Canvas _canvasComponent;
        [SerializeField] ICanvasObject[] canvasElements;

        private ComponentContainer _componentContainer;

        public void Initialize(ComponentContainer componentContainer)
        {
            _componentContainer = componentContainer;
            _canvasComponent = GetComponent<Canvas>();
            canvasElements = transform.GetComponentsInChildren<ICanvasObject>();
            
            Init();
        }

        public Canvas GetCanvasComponent()
        {
            return _canvasComponent;
        }

        public void Activate()
        {
            _canvasComponent.enabled = true;

            for (int i = 0; i < canvasElements.Length; i++)
            {
                if (canvasElements[i] != null)
                {
                    canvasElements[i].Activate();
                }
            }
        }

        public void Deactivate()
        {
            _canvasComponent.enabled = false;

            for (int i = 0; i < canvasElements.Length; i++)
            {
                if (canvasElements[i] != null)
                {
                    canvasElements[i].Deactivate();
                }
            }
        }

        protected virtual void Init()
        {
            for (int i = 0; i < canvasElements.Length; i++)
            {
                canvasElements[i].Init();
            }
        }

        public void ReturnToMainMenu()
        {
            if (OnReturnToMainMenu != null)
            {
                OnReturnToMainMenu();
            }
        }
    }
}