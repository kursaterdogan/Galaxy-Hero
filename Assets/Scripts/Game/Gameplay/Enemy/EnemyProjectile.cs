using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class EnemyProjectile : Projectile
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
                Destroy(gameObject);
            else if (col.CompareTag("Bombeo"))
                Destroy(gameObject);
        }

        protected override void CheckDestroyPosition()
        {
            if (transform.position.y < DestroyPosition)
                Destroy(gameObject);
        }
    }
}