using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemy
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