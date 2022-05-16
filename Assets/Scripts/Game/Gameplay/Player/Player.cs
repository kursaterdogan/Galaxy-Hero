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
        [SerializeField] private CircleCollider2D col2D;

        private GameCamera _gameCamera;
        private PlayerProjectilePool _playerProjectilePool;
        private List<Transform> _firePoints;
        private SuperPower _activeSuperPower;

        private WaitForSeconds _superPowerCooldownWaitForSeconds;
        private WaitForSeconds _shildeoDurationWaitForSeconds;
        private WaitForSeconds _ghosteoDurationWaitForSeconds;
        private WaitForSeconds _fireRateWaitForSeconds;

        [SerializeField] private GameObject bombeoPrefab;
        [SerializeField] private Transform bombeoFirePoint;
        private float _bombeoScale;
        private float _bombeoDestroyPosition;
        private bool _isShildeoActive;

        private int _health;
        private int _cannonLevel;
        private float _speed = 5.0f;
        private Vector2 _velocity;

        //TODO Refactor Usage of Super Powers
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
            if (_isShildeoActive)
                return;

            if (col.CompareTag("EnemyProjectile") || col.CompareTag("Enemy"))
                DecreaseHealth();
        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
                DecreaseHealth();
        }

        void OnDestroy()
        {
            SetTimeScale(_normalTimeScale);
        }

        public void OnLaunch()
        {
            SetTimeScale(_defaultTimeScale);
            StartCoroutine(FireCoroutine());
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

            if (_health > 0)
                return;

            GameManager.SharedInstance.CompleteGame();
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

        public void SetSuperPowerCooldown(float superPowerCooldown)
        {
            _superPowerCooldownWaitForSeconds = new WaitForSeconds(superPowerCooldown);
        }

        public void SetShildeoDuration(float shildeoDuration)
        {
            _shildeoDurationWaitForSeconds = new WaitForSeconds(shildeoDuration);
        }

        public void SetBombeoScale(float bombeoScale)
        {
            _bombeoScale = bombeoScale;
        }

        public void SetGhosteoDuration(float ghosteoDuration)
        {
            _ghosteoDurationWaitForSeconds = new WaitForSeconds(ghosteoDuration);
        }

        public void SetBombeoDestroyPosition(float destroyPosition)
        {
            _bombeoDestroyPosition = destroyPosition;
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
                Vector2 worldPosition = _gameCamera.GetScreenToWorldPoint(Pointer.current.position.ReadValue());
                transform.position = Vector2.SmoothDamp(transform.position,
                    worldPosition, ref _velocity, _speed * Time.deltaTime);
            }
        }

        private IEnumerator FireCoroutine()
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
                yield return _superPowerCooldownWaitForSeconds;
                shildeoParticleSystem.Play();
                col2D.radius *= 2;
                _isShildeoActive = true;
                yield return _shildeoDurationWaitForSeconds;
                shildeoParticleSystem.Stop();
                col2D.radius /= 2;
                _isShildeoActive = false;
            }
        }

        private IEnumerator Bombeo()
        {
            while (true)
            {
                yield return _superPowerCooldownWaitForSeconds;
                GameObject bombeo = Instantiate(bombeoPrefab, bombeoFirePoint.position, Quaternion.identity);
                bombeo.transform.localScale = new Vector3(_bombeoScale, _bombeoScale, 1);
                bombeo.GetComponent<Bombeo>().SetDestroyPosition(_bombeoDestroyPosition);
            }
        }

        private IEnumerator Ghosteo()
        {
            while (true)
            {
                yield return _superPowerCooldownWaitForSeconds;
                ghosteoParticleSystem.Play();
                col2D.enabled = false;
                yield return _ghosteoDurationWaitForSeconds;
                ghosteoParticleSystem.Stop();
                col2D.enabled = true;
            }
        }

        private void CreateDeathParticle()
        {
            Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        }
    }
}