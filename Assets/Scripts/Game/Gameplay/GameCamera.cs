using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay
{
    public class GameCamera : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private Camera _mainCamera;
        private float _aspect;
        private float _screenBoundsWidth;
        private float _screenBoundsHeight;
        private float _padding = 10f;
        private float _maxVerticalPosition;

        void Awake()
        {
            SetCamera();
            SetAspect();
            SetMoveBoundaries();
            SetMaxVerticalPosition();
        }

        public Vector3 GetScreenToWorldPoint(Vector3 screenPosition)
        {
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);

            return worldPosition;
        }

        public bool IsPointerOnScreen()
        {
            float pointerXPosition = Pointer.current.position.ReadValue().x;
            float pointerYPosition = Pointer.current.position.ReadValue().y;

            bool isPointerOnScreen = pointerXPosition < _screenBoundsWidth - _padding &&
                                     pointerXPosition > 0 + _padding &&
                                     pointerYPosition < _screenBoundsHeight - _padding &&
                                     pointerYPosition > 0 + _padding;

            return isPointerOnScreen;
        }

        public float GetMaxVerticalPosition()
        {
            return _maxVerticalPosition;
        }

        public float GetAspectRatio()
        {
            return _aspect;
        }

        private void SetCamera()
        {
            _mainCamera = Camera.main;
        }

        private void SetAspect()
        {
            _aspect = _mainCamera.aspect;
        }

        private void SetMoveBoundaries()
        {
            _screenBoundsHeight = Screen.height;
            _screenBoundsWidth = Screen.width;
        }

        private void SetMaxVerticalPosition()
        {
            _maxVerticalPosition = _mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y;
        }
    }
}