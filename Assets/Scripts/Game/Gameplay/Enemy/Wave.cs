using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int enemyCount;
        [SerializeField] private float spawnCooldown;

        public GameObject GetEnemy()
        {
            return enemyPrefab;
        }

        public int GetEnemyCount()
        {
            return enemyCount;
        }

        public float GetSpawnCooldown()
        {
            return spawnCooldown;
        }
    }
}