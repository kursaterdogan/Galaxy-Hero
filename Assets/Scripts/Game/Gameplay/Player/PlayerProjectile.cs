using UnityEngine;

namespace Game.Gameplay.Player
{
    public class PlayerProjectile : Projectile
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
                gameObject.SetActive(false);
        }

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