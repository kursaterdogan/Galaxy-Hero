namespace Game.Gameplay.Player
{
    public class Bombeo : Projectile
    {
        protected override void CheckDestroyPosition()
        {
            if (transform.position.y > DestroyPosition)
                Destroy(gameObject);
        }
    }
}