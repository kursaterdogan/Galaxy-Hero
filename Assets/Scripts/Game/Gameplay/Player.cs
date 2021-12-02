namespace Game.Gameplay
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Player : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        private GameCamera _gameCamera;
        private float _moveSpeed = 5f;
        private float _passiveMoveSpeed;

        private void Start()
        {
            //TODO SetMoveSpeed
            //TODO SetTimeScale on InGameState
            Time.timeScale = 0.5f;
            SetGameCamera();
            SetPassiveSpeed();
        }

        private void Update()
        {
            Move();
            TriggerPassiveMoving();
        }

        private void SetGameCamera()
        {
            _gameCamera = FindObjectOfType<GameCamera>();
        }

        private void SetPassiveSpeed()
        {
            _passiveMoveSpeed = _gameCamera.GetPassiveMoveSpeed();
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
            bool isPointerOnScreen = _gameCamera.IsPointerOnScreen();
            if (isPointerOnScreen && Mouse.current.leftButton.isPressed)
            {
                Vector3 worldPosition = _gameCamera.GetScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = Vector2.Lerp(transform.position, worldPosition, _moveSpeed * Time.deltaTime);
            }
        }

        private void TriggerPassiveMoving()
        {
            transform.Translate(Vector3.up * _passiveMoveSpeed * Time.deltaTime, Space.World);
        }
    }
}