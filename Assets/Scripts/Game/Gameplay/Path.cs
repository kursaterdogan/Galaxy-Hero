using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Transform> waypoints;

        public List<Transform> GetWaypoints()
        {
            return waypoints;
        }
    }
}