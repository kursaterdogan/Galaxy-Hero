using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        protected abstract void Attack();

        [SerializeField] private Path path;
        private List<Transform> _waypoints;
        private int _waypointIndex;

        [SerializeField] protected float score;
        [SerializeField] protected int health;
        [SerializeField] protected float speed;

        void Start()
        {
            SetWaypoints();
            SetStartPosition();
        }

        void Update()
        {
            FollowPath();
        }

        private void SetWaypoints()
        {
            _waypoints = path.GetWaypoints();
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
    }
}