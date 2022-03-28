using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Wave> waves;

        [SerializeField] private float waveSpawnCooldown;
        private WaitForSeconds _waveSpawnWaitForSeconds;

        void Start()
        {
            SetWaveSpawnWaitForSeconds();
            StartSpawnCoroutine();
        }

        private void SetWaveSpawnWaitForSeconds()
        {
            _waveSpawnWaitForSeconds = new WaitForSeconds(waveSpawnCooldown);
        }

        private void StartSpawnCoroutine()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            foreach (Wave wave in waves)
            {
                GameObject enemy = wave.GetEnemy();
                int enemyCount = wave.GetEnemyCount();
                WaitForSeconds enemySpawnWaitForSeconds = new WaitForSeconds(wave.GetSpawnCooldown());

                for (int i = 0; i < enemyCount; i++)
                {
                    Instantiate(enemy, transform);
                    yield return enemySpawnWaitForSeconds;
                }

                yield return _waveSpawnWaitForSeconds;
            }
        }
    }
}