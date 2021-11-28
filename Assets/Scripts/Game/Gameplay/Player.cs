namespace Game.Gameplay
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Player : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private Camera _gameCamera;
        private int _screenBoundsWidth;
        private int _screenBoundsHeight;
        private float _padding = 50f;

        private float _moveSpeed = 5f;

        private void Start()
        {
            //TODO SetMoveSpeed
            SetGameCamera();
            SetBoundaries();
        }

        void Update()
        {
            Move();
        }

        private void SetGameCamera()
        {
            _gameCamera = Camera.main;
        }

        private void SetBoundaries()
        {
            _screenBoundsHeight = Screen.height;
            _screenBoundsWidth = Screen.width;
        }

        public void OnMove(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
            {
                Time.timeScale = 1f;
            }
            else if (callbackContext.canceled)
            {
                Time.timeScale = 0.5f;
            }
        }

        private void Move()
        {
            //TODO Check for mobile device
            if (IsPointerOnScreen() && Mouse.current.leftButton.isPressed)
            {
                Vector3 worldPosition = _gameCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = Vector2.Lerp(transform.position, worldPosition, _moveSpeed * Time.deltaTime);
            }
        }

        private bool IsPointerOnScreen()
        {
            float pointerXPosition = Mouse.current.position.ReadValue().x;
            float pointerYPosition = Mouse.current.position.ReadValue().y;

            bool isPointerOnScreen = pointerXPosition < _screenBoundsWidth - _padding &&
                                     pointerXPosition > 0 + _padding &&
                                     pointerYPosition < _screenBoundsHeight - _padding &&
                                     pointerYPosition > 0 + _padding;

            if (isPointerOnScreen)
            {
                return true;
            }

            return false;
        }
    }
}