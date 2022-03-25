using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        //TODO Inject GameCamera
        private GameCamera _gameCamera;
        private float _moveSpeed = 5.0f;

        private ProjectilePool _projectilePool;
        private WaitForSeconds _fireRateWaitForSeconds;
        private Coroutine _firingCoroutine;
        [SerializeField] private Cannon cannon;
        [SerializeField] private int cannonLevel;
        private List<Transform> _firePoints;
        private float _fireRate = 1;

        void Start()
        {
            //TODO SetMoveSpeed
            //TODO SetTimeScale on InGameState
            //TODO Set ProjectileSpeed & ProjectileFiringPeriod
            Time.timeScale = 0.5f;
            SetGameCamera();
            SetFirePoints();
            SetProjectilePool();
            SetFiringWaitForSeconds();
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

        public void SetFireRate(int fireRateLevel)
        {
            _fireRate /= fireRateLevel;
        }

        public void OnMove(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
                Time.timeScale = 1f;
            else if (callbackContext.canceled)
                Time.timeScale = 0.5f;
        }

        private void SetGameCamera()
        {
            _gameCamera = FindObjectOfType<GameCamera>();
        }

        private void SetFirePoints()
        {
            _firePoints = cannon.GetFirePoints(cannonLevel);
        }

        private void SetProjectilePool()
        {
            _projectilePool = FindObjectOfType<ProjectilePool>();
        }

        private void SetFiringWaitForSeconds()
        {
            _fireRateWaitForSeconds = new WaitForSeconds(_fireRate);
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
                foreach (Transform firePoint in _firePoints)
                {
                    PlayerProjectile projectile = _projectilePool.GetPlayerProjectile();
                    projectile.SetPosition(firePoint.transform.position);
                    projectile.gameObject.SetActive(true);
                }

                yield return _fireRateWaitForSeconds;
            }
        }
    }
}