namespace Base.UserInterface
{
    using Component;
    using UnityEngine;

    [RequireComponent(typeof(Canvas))]
    public abstract class BaseCanvas : MonoBehaviour
    {
        private Canvas _canvasComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            _canvasComponent = GetComponent<Canvas>();
        }

        protected virtual void Init()
        {
        }

        public void Activate()
        {
            _canvasComponent.enabled = true;
        }

        public void Deactivate()
        {
            _canvasComponent.enabled = false;
        }
    }
}