using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class Shooter : Enemy
    {
        //TODO Shooter
        [SerializeField] private EnemyProjectile enemyProjectilePrefab;
        [SerializeField] private Transform firingPoint;

        protected override void Attack()
        {
            EnemyProjectile enemyProjectile =
                Instantiate(enemyProjectilePrefab, firingPoint.position, Quaternion.identity);

            enemyProjectile.SetDestroyPosition(DestroyPosition);
        }
    }
}