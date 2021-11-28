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
        private float _padding = 50f;
        private float _passiveMoveSpeed = 1f;

        private void Start()
        {
            SetCamera();
            SetMoveBoundaries();
        }

        void LateUpdate()
        {
            //TODO Trigger this on InGameState
            TriggerPassiveMoving();
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

        private void TriggerPassiveMoving()
        {
            _mainCamera.transform.Translate(Vector3.up * _passiveMoveSpeed * Time.deltaTime, Space.World);
        }

        public Vector3 GetScreenToWorldPoint(Vector3 screenPosition)
        {
            return _mainCamera.ScreenToWorldPoint(screenPosition);
        }

        public bool IsPointerOnScreen()
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

        public float GetPassiveMoveSpeed()
        {
            return _passiveMoveSpeed;
        }

        public Transform GetTransform()
        {
            return _mainCamera.GetComponent<Transform>();
        }
    }
}