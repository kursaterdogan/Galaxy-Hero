namespace Game.Gameplay
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using System.Collections;

    public class Player : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        //TODO Inject GameCamera
        private GameCamera _gameCamera;
        private float _moveSpeed = 5f;

        private ProjectilePool _projectilePool;
        private Coroutine _firingCoroutine;
        [SerializeField] private Transform firingPoint;
        float _projectileSpeed = 15f;
        float _projectileFiringPeriod = 0.2f;

        private void Start()
        {
            //TODO SetMoveSpeed
            //TODO SetTimeScale on InGameState
            //TODO Set ProjectileSpeed & ProjectileFiringPeriod
            Time.timeScale = 0.5f;
            SetGameCamera();
            SetProjectilePool();
            StartFiringCoroutine();
        }

        private void Update()
        {
            Move();
        }

        private void SetGameCamera()
        {
            _gameCamera = FindObjectOfType<GameCamera>();
        }

        private void SetProjectilePool()
        {
            _projectilePool = FindObjectOfType<ProjectilePool>();
        }

        private void StartFiringCoroutine()
        {
            _firingCoroutine = StartCoroutine(FireContinously());
        }

        private void StopFiringCoroutine()
        {
            StopCoroutine(_firingCoroutine);
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
            if (_gameCamera.IsPointerOnScreen() && Mouse.current.leftButton.isPressed)
            {
                Vector3 worldPosition = _gameCamera.GetScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = Vector2.Lerp(transform.position, worldPosition, _moveSpeed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // TODO Check EnemyTrigger
            // Debug.Log(col.name);
        }

        IEnumerator FireContinously()
        {
            while (true)
            {
                GameObject laser = _projectilePool.GetPlayerProjectile();
                laser.transform.position = firingPoint.position;
                laser.SetActive(true);
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _projectileSpeed);
                yield return new WaitForSeconds(_projectileFiringPeriod);
            }
        }
    }
}