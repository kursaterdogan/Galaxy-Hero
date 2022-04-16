using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class FirePoint : MonoBehaviour
    {
        [SerializeField] private List<Transform> firePoints;

        public List<Transform> GetFirePoints()
        {
            return firePoints;
        }
    }
}