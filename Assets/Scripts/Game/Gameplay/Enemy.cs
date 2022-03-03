using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private Path path;
        private List<Transform> _waypoints;
        private int _waypointIndex;
        [SerializeField] private float speed;
        [SerializeField] private int health;

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