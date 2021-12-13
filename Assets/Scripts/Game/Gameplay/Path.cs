namespace Game.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Transform> waypoints;

        public List<Transform> GetWaypoints()
        {
            return waypoints;
        }
    }
}