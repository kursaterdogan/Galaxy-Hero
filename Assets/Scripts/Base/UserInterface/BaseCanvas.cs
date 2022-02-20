using Base.Component;
using UnityEngine;

namespace Base.UserInterface
{
    [RequireComponent(typeof(Canvas))]
    public abstract class BaseCanvas : MonoBehaviour
    {
        private Canvas _canvasComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            _canvasComponent = GetComponent<Canvas>();
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