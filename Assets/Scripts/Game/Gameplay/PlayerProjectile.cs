using UnityEngine;

namespace Game.Gameplay
{
    public class PlayerProjectile : MonoBehaviour
    {
        private float _maxVerticalPosition;

        void Start()
        {
            SetMaxVerticalPosition();
        }

        void Update()
        {
            CheckDestroyPosition();
        }

        private void SetMaxVerticalPosition()
        {
            GameCamera gameCamera = FindObjectOfType<GameCamera>();
            _maxVerticalPosition = gameCamera.GetMaxVerticalPosition();
        }

        private void CheckDestroyPosition()
        {
            if (transform.position.y > _maxVerticalPosition)
                gameObject.SetActive(false);
        }
    }
}