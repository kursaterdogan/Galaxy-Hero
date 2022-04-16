using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemy.Boss
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] private Ability[] abilities;
        [SerializeField] private Cannon cannon;
        [SerializeField] private int score;
        [SerializeField] private int health;
        [SerializeField] private float speed;
        [SerializeField] private GameObject deathParticle;

        private Ability _activeAbility;
        private List<Transform> _waypoints;
        private int _firePointLevel;
        private EnemyProjectile _enemyProjectile;

        private List<Transform> _firePoints;
        private float _minVerticalPosition;
        private int _abilityIndex;
        private int _waypointIndex;

        void Start()
        {
            SetMaxVerticalPosition();
            ChangeAbility();
        }

        void Update()
        {
            FollowPath();
            Debug.LogWarning(health);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            // TODO Handle Player
            if (col.CompareTag("PlayerProjectile"))
            {
                CreateDeathParticle();
                health--;

                if (health > 0)
                    return;

                IncreaseScore();
                Destroy(gameObject);
            }
        }

        private void SetMaxVerticalPosition()
        {
            _minVerticalPosition = FindObjectOfType<GameCamera>().GetMinVerticalPosition();
        }

        private void CreateDeathParticle()
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }

        private void IncreaseScore()
        {
            GameManager.SharedInstance.IncreaseScore(score);
        }

        private void FollowPath()
        {
            if (_waypointIndex < _waypoints.Count)
            {
                Vector2 targetPosition = _waypoints[_waypointIndex].position;
                float delta = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

                if (transform.position.Equals(targetPosition))
                {
                    Attack();
                    _waypointIndex++;
                }
            }
            else
            {
                ChangeAbility();
                _waypointIndex = 0;
            }
        }

        private void Attack()
        {
            foreach (Transform firePoint in _firePoints)
            {
                EnemyProjectile enemyProjectile =
                    Instantiate(_enemyProjectile, firePoint.position, Quaternion.identity);
                enemyProjectile.SetDestroyPosition(_minVerticalPosition);
            }
        }

        private void ChangeAbility()
        {
            SetActiveAbility();
            UseAbility();
        }

        private void SetActiveAbility()
        {
            _activeAbility = abilities[_abilityIndex];

            if (_abilityIndex == abilities.Length - 1)
                _abilityIndex = 0;
            else
                _abilityIndex++;
        }

        private void UseAbility()
        {
            health += _activeAbility.GetExtraHealth();
            _waypoints = _activeAbility.GetWaypoints();
            _firePointLevel = _activeAbility.GetFirePointLevel();
            _firePoints = cannon.GetFirePoints(_firePointLevel);
            _enemyProjectile = _activeAbility.GetBossProjectile();
        }
    }
}