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
        [SerializeField] private ICanvasObject[] canvasElements;

        private ComponentContainer _componentContainer;

        public void Initialize(ComponentContainer componentContainer)
        {
            _componentContainer = componentContainer;
            _canvasComponent = GetComponent<Canvas>();
            canvasElements = transform.GetComponentsInChildren<ICanvasObject>();

            PreInit();
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

        protected virtual void PreInit()
        {
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

        protected Vector2 GetCanvasSize()
        {
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

            var screenMatchMode = canvasScaler.screenMatchMode;
            var referenceResolution = canvasScaler.referenceResolution;
            var matchWidthOrHeight = canvasScaler.matchWidthOrHeight;

            float scaleFactor = 0;
            float logWidth = Mathf.Log(screenSize.x / referenceResolution.x, 2);
            float logHeight = Mathf.Log(screenSize.y / referenceResolution.y, 2);
            float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, matchWidthOrHeight);
            scaleFactor = Mathf.Pow(2, logWeightedAverage);

            return new Vector2(screenSize.x / scaleFactor, screenSize.y / scaleFactor);
        }
    }
}