using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemy.Boss
{
    [CreateAssetMenu(fileName = "Ability", menuName = "Scriptable Objects/Ability", order = 1)]
    public class Ability : ScriptableObject
    {
        [SerializeField] private Path path;
        [SerializeField] private int firePointLevel;
        [SerializeField] private EnemyProjectile enemyProjectile;
        [SerializeField] private int extraHealth;

        public List<Transform> GetWaypoints()
        {
            return path.GetWaypoints();
        }

        public int GetFirePointLevel()
        {
            return firePointLevel;
        }

        public EnemyProjectile GetBossProjectile()
        {
            return enemyProjectile;
        }

        public int GetExtraHealth()
        {
            return extraHealth;
        }
    }
}