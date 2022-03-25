using UnityEngine;

namespace Game.Gameplay.Player
{
    public class PlayerProjectile : Projectile
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        protected override void CheckDestroyPosition()
        {
            if (transform.position.y > DestroyPosition)
                gameObject.SetActive(false);
        }
    }
}