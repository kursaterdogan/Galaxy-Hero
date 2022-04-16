using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        protected abstract void Attack();

        [SerializeField] protected int score;
        [SerializeField] protected int health;
        [SerializeField] protected float speed;
        protected float DestroyPosition;

        [SerializeField] private Path path;
        private List<Transform> _waypoints;
        private int _waypointIndex;

        [SerializeField] private GameObject deathParticlePrefab;

        void Start()
        {
            SetWaypoints();
            SetDestroyPosition();
            SetStartPosition();
        }

        void Update()
        {
            FollowPath();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("PlayerProjectile"))
            {
                CreateDeathParticle();
                health--;

                if (health > 0)
                    return;

                IncreaseScore();
                Destroy(gameObject);
            }
            else if (col.CompareTag("Player") || col.CompareTag("Bombeo"))
            {
                CreateDeathParticle();
                IncreaseScore();
                Destroy(gameObject);
            }
        }

        private void SetWaypoints()
        {
            _waypoints = path.GetWaypoints();
        }

        private void SetDestroyPosition()
        {
            DestroyPosition = FindObjectOfType<GameCamera>().GetMinVerticalPosition();
        }

        private void SetStartPosition()
        {
            transform.position = _waypoints[_waypointIndex].position;
            _waypointIndex++;
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
                Destroy(gameObject);
            }
        }

        private void CreateDeathParticle()
        {
            Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        }

        private void IncreaseScore()
        {
            GameManager.SharedInstance.IncreaseScore(score);
        }
    }
}