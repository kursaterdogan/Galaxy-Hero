using Base.Component;
using UnityEngine;

namespace Base.UserInterface
{
    [RequireComponent(typeof(Canvas))]
    public abstract class BaseCanvas : MonoBehaviour
    {
        private Canvas _canvas;

        public void Initialize(ComponentContainer componentContainer)
        {
            _canvas = GetComponent<Canvas>();
        }

        public void Activate()
        {
            _canvas.enabled = true;
        }

        public void Deactivate()
        {
            _canvas.enabled = false;
        }
    }
}