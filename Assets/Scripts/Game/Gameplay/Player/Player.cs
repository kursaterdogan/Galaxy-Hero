using System.Collections;
using System.Collections.Generic;
using Base.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay.Player
{
    public class Player : MonoBehaviour, ILaunchable
    {
        //TODO Integrate with StateMachine
        //TODO Inject GameCamera
        private const float DefaultTimeScale = 0.5f;
        private const float NormalTimeScale = 1.0f;

        private GameCamera _gameCamera;
        private float _moveSpeed = 5.0f;

        private ProjectilePool _projectilePool;
        private WaitForSeconds _fireRateWaitForSeconds;

        [SerializeField] private Cannon cannon;
        [SerializeField] private int cannonLevel;
        private List<Transform> _firePoints;
        private float _fireRate = 1.0f;

        void Start()
        {
            //TODO SetMoveSpeed
            //TODO SetTimeScale on InGameState
            //TODO Set ProjectileSpeed & ProjectileFiringPeriod
            SetTimeScale(DefaultTimeScale);
            SetGameCamera();
            SetFirePoints();
            SetProjectilePool();
            SetFiringWaitForSeconds();
            
            OnLaunch();
        }

        void Update()
        {
            Move();
        }

        public void OnLaunch()
        {
            StartFiringCoroutine();
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
                SetTimeScale(NormalTimeScale);
            else if (callbackContext.canceled)
                SetTimeScale(DefaultTimeScale);
        }

        private void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
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
            StartCoroutine(FireContinously());
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