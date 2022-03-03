using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.Gameplay
{
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

        void Start()
        {
            //TODO SetMoveSpeed
            //TODO SetTimeScale on InGameState
            //TODO Set ProjectileSpeed & ProjectileFiringPeriod
            Time.timeScale = 0.5f;
            SetGameCamera();
            SetProjectilePool();
            StartFiringCoroutine();
        }

        void Update()
        {
            Move();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            // TODO Check EnemyTrigger
            // Debug.Log(col.name);
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
            //TODO HandleFiringCoroutine
            StopCoroutine(_firingCoroutine);
        }

        private void Move()
        {
            if (_gameCamera.IsPointerOnScreen() && Pointer.current.press.isPressed)
            {
                Vector3 worldPosition = _gameCamera.GetScreenToWorldPoint(Pointer.current.position.ReadValue());
                transform.position = Vector2.Lerp(transform.position, worldPosition, _moveSpeed * Time.deltaTime);
            }
        }

        private IEnumerator FireContinously()
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