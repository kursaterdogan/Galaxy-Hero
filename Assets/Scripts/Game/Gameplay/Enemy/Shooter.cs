using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class Shooter : Enemy
    {
        //TODO Shooter
        [SerializeField] private EnemyProjectile enemyProjectilePrefab;
        [SerializeField] private Transform[] firePoints;

        protected override void Attack()
        {
            foreach (Transform firePoint in firePoints)
            {
                EnemyProjectile enemyProjectile =
                    Instantiate(enemyProjectilePrefab, firePoint.position, Quaternion.identity);
                enemyProjectile.SetDestroyPosition(DestroyPosition);
            }
        }
    }
}