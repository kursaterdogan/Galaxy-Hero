using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Base.Gameplay;

namespace Game.Gameplay.Player
{
    public class Player : MonoBehaviour, ILaunchable
    {
        private const float DefaultTimeScale = 0.5f;
        private const float NormalTimeScale = 1.0f;

        private GameCamera _gameCamera;
        private PlayerProjectilePool _playerProjectilePool;

        private WaitForSeconds _fireRateWaitForSeconds;

        [SerializeField] private Cannon cannon;
        private List<Transform> _firePoints;

        private int _health;
        private int _cannonLevel;
        private float _speed = 5.0f;
        private float _fireRate = 1.0f;

        [SerializeField] private GameObject deathParticlePrefab;

        void Start()
        {
            SetGameCamera();
            SetPlayerProjectilePool();
        }

        void Update()
        {
            Move();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            //TODO Add Shildeo & Ghosteo
            if (col.CompareTag("EnemyProjectile"))
            {
                DecreaseHealth();
            }
            else if (col.CompareTag("Enemy"))
            {
                DecreaseHealth();
            }
        }

        void OnDestroy()
        {
            SetTimeScale(NormalTimeScale);
        }

        public void OnLaunch()
        {
            SetTimeScale(DefaultTimeScale);
            StartFiringCoroutine();
        }

        private void DecreaseHealth()
        {
            CreateDeathParticle();
            _health--;
            GameManager.SharedInstance.DecreaseHealth(_health);
        }

        private void SetGameCamera()
        {
            _gameCamera = FindObjectOfType<GameCamera>();
        }

        private void SetPlayerProjectilePool()
        {
            _playerProjectilePool = FindObjectOfType<PlayerProjectilePool>();
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetCannonLevel(int cannonLevel)
        {
            _cannonLevel = cannonLevel;
            SetFirePoints();
        }

        public void SetFireRate(float fireRate)
        {
            _fireRate = fireRate;
            SetFiringWaitForSeconds();
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

        private void SetFirePoints()
        {
            _firePoints = cannon.GetFirePoints(_cannonLevel);
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
            if (Pointer.current.press.isPressed && _gameCamera.IsPointerOnScreen())
            {
                Vector3 worldPosition = _gameCamera.GetScreenToWorldPoint(Pointer.current.position.ReadValue());
                transform.position = Vector2.Lerp(transform.position, worldPosition, _speed * Time.deltaTime);
            }
        }

        private IEnumerator FireContinously()
        {
            while (true)
            {
                foreach (Transform firePoint in _firePoints)
                {
                    PlayerProjectile projectile = _playerProjectilePool.GetPlayerProjectile();
                    projectile.SetPosition(firePoint.transform.position);
                    projectile.gameObject.SetActive(true);
                }

                yield return _fireRateWaitForSeconds;
            }
        }

        private void CreateDeathParticle()
        {
            Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        }
    }
}