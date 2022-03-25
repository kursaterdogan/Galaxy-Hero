using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private FirePoint[] levels;

        public List<Transform> GetFirePoints(int cannonLevel)
        {
            FirePoint firePoint = levels[cannonLevel];

            return firePoint.GetFirePoints();
        }
    }
}