namespace Game.Gameplay.Enemy
{
    public class EnemyProjectile : Projectile
    {
        protected override void CheckDestroyPosition()
        {
            if (transform.position.y < DestroyPosition)
                Destroy(gameObject);
        }
    }
}