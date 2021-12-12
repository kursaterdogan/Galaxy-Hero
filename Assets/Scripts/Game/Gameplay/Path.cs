namespace Game.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Path : MonoBehaviour
    {
        private List<Transform> _waypoints;

        // Start is called before the first frame update
        void Start()
        {
            SetWayPoints();
        }

        private void SetWayPoints()
        {
            _waypoints = new List<Transform>();
            foreach (Transform child in transform)
            {
                _waypoints.Add(child);
            }
        }

        public List<Transform> GetWaypoints()
        {
            return _waypoints;
        }
    }
}