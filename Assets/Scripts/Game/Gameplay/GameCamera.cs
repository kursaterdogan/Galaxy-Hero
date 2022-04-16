using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay
{
    public class GameCamera : MonoBehaviour
    {
        private const float _aspectPadding = 0.05f;
        private const float _screenBoundPadding = 10.0f;

        private Camera _mainCamera;

        private float _aspect;
        private float _screenBoundWidth;
        private float _screenBoundHeight;
        private float _minVerticalPosition;
        private float _maxVerticalPosition;

        void Awake()
        {
            SetCamera();
            SetAspect();
            SetMoveBoundaries();
            SetMaxVerticalPosition();
            SetMinVerticalPosition();
        }

        public Vector2 GetScreenToWorldPoint(Vector2 screenPosition)
        {
            Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);

            return worldPosition;
        }

        public bool IsPointerOnScreen()
        {
            float pointerXPosition = Pointer.current.position.ReadValue().x;
            float pointerYPosition = Pointer.current.position.ReadValue().y;

            bool isPointerOnScreen = pointerXPosition < _screenBoundWidth - _screenBoundPadding
                                     &&
                                     pointerXPosition > _screenBoundPadding
                                     &&
                                     pointerYPosition < _screenBoundHeight - _screenBoundPadding
                                     &&
                                     pointerYPosition > _screenBoundPadding;

            return isPointerOnScreen;
        }

        public float GetMaxVerticalPosition()
        {
            return _maxVerticalPosition;
        }

        public float GetMinVerticalPosition()
        {
            return _minVerticalPosition;
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
            _aspect = _mainCamera.aspect + _aspectPadding;
        }

        private void SetMoveBoundaries()
        {
            _screenBoundHeight = Screen.height;
            _screenBoundWidth = Screen.width;
        }

        private void SetMinVerticalPosition()
        {
            _minVerticalPosition = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).y;
        }

        private void SetMaxVerticalPosition()
        {
            _maxVerticalPosition = _mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y;
        }
    }
}