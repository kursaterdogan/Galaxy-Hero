using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay
{
    public class GameCamera : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private const float AspectPadding = 0.05f;
        private const float ScreenBoundPadding = 10f;

        private Camera _mainCamera;

        private float _aspect;
        private float _screenBoundWidth;
        private float _screenBoundHeight;
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

            bool isPointerOnScreen = pointerXPosition < _screenBoundWidth - ScreenBoundPadding
                                     &&
                                     pointerXPosition > ScreenBoundPadding
                                     &&
                                     pointerYPosition < _screenBoundHeight - ScreenBoundPadding
                                     &&
                                     pointerYPosition > ScreenBoundPadding;

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
            _aspect = _mainCamera.aspect + AspectPadding;
        }

        private void SetMoveBoundaries()
        {
            _screenBoundHeight = Screen.height;
            _screenBoundWidth = Screen.width;
        }

        private void SetMaxVerticalPosition()
        {
            _maxVerticalPosition = _mainCamera.ViewportToWorldPoint(new Vector2(0, 1)).y;
        }
    }
}