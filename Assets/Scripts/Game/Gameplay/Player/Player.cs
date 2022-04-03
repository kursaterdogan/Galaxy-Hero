using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Base.Gameplay;
using Game.Enums;

namespace Game.Gameplay.Player
{
    public class Player : MonoBehaviour, ILaunchable
    {
        private const float _defaultTimeScale = 0.5f;
        private const float _normalTimeScale = 1.0f;

        [SerializeField] private GameObject deathParticlePrefab;
        [SerializeField] private ParticleSystem shildeoParticleSystem;
        [SerializeField] private ParticleSystem ghosteoParticleSystem;
        [SerializeField] private Cannon cannon;

        private GameCamera _gameCamera;
        private PlayerProjectilePool _playerProjectilePool;

        private List<Transform> _firePoints;
        private SuperPower _activeSuperPower;

        private WaitForSeconds _superPowerWaitForSeconds;
        private WaitForSeconds _shildeoWaitForSeconds;
        private WaitForSeconds _bombeoWaitForSeconds;
        private WaitForSeconds _ghosteoWaitForSeconds;
        private WaitForSeconds _fireRateWaitForSeconds;

        private int _health;
        private int _cannonLevel;
        private float _speed = 5.0f;

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
                DecreaseHealth();
            else if (col.CompareTag("Enemy"))
                DecreaseHealth();
        }

        void OnDestroy()
        {
            SetTimeScale(_normalTimeScale);
        }

        public void OnLaunch()
        {
            SetTimeScale(_defaultTimeScale);
            StartCoroutine(FireContinously());
            StartSuperPower();
        }

        private void StartSuperPower()
        {
            switch (_activeSuperPower)
            {
                case SuperPower.Shildeo:
                    StartCoroutine(Shildeo());
                    break;
                case SuperPower.Bombeo:
                    StartCoroutine(Bombeo());
                    break;
                case SuperPower.Ghosteo:
                    StartCoroutine(Ghosteo());
                    break;
            }
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

        public void SetFireDuration(float fireRate)
        {
            _fireRateWaitForSeconds = new WaitForSeconds(fireRate);
        }

        public void SetActiveSuperPower(SuperPower superPower)
        {
            _activeSuperPower = superPower;
        }

        public void SetSuperPowerDuration(float superPowerDuration)
        {
            Debug.LogWarning(superPowerDuration);
            _superPowerWaitForSeconds = new WaitForSeconds(superPowerDuration);
        }

        public void SetShildeoDuration(float shildeoDuration)
        {
            _shildeoWaitForSeconds = new WaitForSeconds(shildeoDuration);
        }

        public void SetBombeoDuration(float bombeoDuration)
        {
            _bombeoWaitForSeconds = new WaitForSeconds(bombeoDuration);
        }

        public void SetGhosteoDuration(float ghosteoDuration)
        {
            _ghosteoWaitForSeconds = new WaitForSeconds(ghosteoDuration);
        }

        public void OnMove(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
                SetTimeScale(_normalTimeScale);
            else if (callbackContext.canceled)
                SetTimeScale(_defaultTimeScale);
        }

        private void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        private void SetFirePoints()
        {
            _firePoints = cannon.GetFirePoints(_cannonLevel);
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

        private IEnumerator Shildeo()
        {
            while (true)
            {
                yield return _superPowerWaitForSeconds;
                shildeoParticleSystem.Play();
                yield return _shildeoWaitForSeconds;
                shildeoParticleSystem.Stop();
            }
        }

        private IEnumerator Bombeo()
        {
            while (true)
            {
                yield return _superPowerWaitForSeconds;
                yield return _bombeoWaitForSeconds;
            }
        }

        private IEnumerator Ghosteo()
        {
            while (true)
            {
                yield return _superPowerWaitForSeconds;
                ghosteoParticleSystem.Play();
                yield return _ghosteoWaitForSeconds;
                ghosteoParticleSystem.Stop();
            }
        }

        private void CreateDeathParticle()
        {
            Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        }
    }
}