using UnityEngine;

namespace Game.Gameplay
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector3 _length;

        void Start()
        {
            SetStartPosition();
            SetScale();
            SetLength();
        }

        void Update()
        {
            PassiveMove();
        }

        private void SetStartPosition()
        {
            transform.position = new Vector3(0, 0, 0);
        }

        private void SetScale()
        {
            float aspectRatio = FindObjectOfType<GameCamera>().GetAspectRatio();

            transform.localScale = new Vector3(aspectRatio, aspectRatio, transform.localScale.z);
        }

        private void SetLength()
        {
            _length.y = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        private void PassiveMove()
        {
            if (transform.position.y <= -_length.y)
                transform.position += _length;

            transform.Translate(Vector3.down * (speed * Time.deltaTime), Space.World);
        }
    }
}