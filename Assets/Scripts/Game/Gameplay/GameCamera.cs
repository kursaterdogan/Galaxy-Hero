namespace Game.Gameplay
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class GameCamera : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private Camera _mainCamera;
        private int _screenBoundsWidth;
        private int _screenBoundsHeight;
        private float _padding = 10f;

        private void Awake()
        {
            SetCamera();
            SetMoveBoundaries();
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

        private void SetCamera()
        {
            _mainCamera = Camera.main;
        }

        private void SetMoveBoundaries()
        {
            _screenBoundsHeight = Screen.height;
            _screenBoundsWidth = Screen.width;
        }
    }
}