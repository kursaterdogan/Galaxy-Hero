using UnityEngine;

namespace Game.Gameplay.Enemy
{
    //TODO Scriptable Object
    public class Wave : MonoBehaviour
    {
        //TODO Enemy enemyPrefab <- Go to Boss's TODO
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