using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        protected abstract void CheckDestroyPosition();

        [SerializeField] protected Rigidbody2D rb2d;
        protected float DestroyPosition;
        [SerializeField] private float speed = 10f;

        void OnEnable()
        {
            SetVelocity();
        }

        void Update()
        {
            CheckDestroyPosition();
        }

        public void SetDestroyPosition(float destroyPosition)
        {
            DestroyPosition = destroyPosition;
        }

        private void SetVelocity()
        {
            rb2d.velocity = new Vector2(0, speed);
        }
    }
}