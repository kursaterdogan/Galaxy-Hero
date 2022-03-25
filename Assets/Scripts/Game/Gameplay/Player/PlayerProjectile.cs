using UnityEngine;

namespace Game.Gameplay.Player
{
    public class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        private float _projectileSpeed = 10f;
        private float _maxVerticalPosition;

        void OnEnable()
        {
            SetVelocity();
        }

        void Update()
        {
            CheckDestroyPosition();
        }

        public void SetMaxVerticalPosition(float maxVerticalPosition)
        {
            _maxVerticalPosition = maxVerticalPosition;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        private void SetVelocity()
        {
            rb2d.velocity = new Vector2(0, _projectileSpeed);
        }

        private void CheckDestroyPosition()
        {
            if (transform.position.y > _maxVerticalPosition)
                gameObject.SetActive(false);
        }
    }
}