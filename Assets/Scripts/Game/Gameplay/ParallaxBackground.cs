using UnityEngine;

namespace Game.Gameplay
{
    public class ParallaxBackground : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        [SerializeField] private float speed;
        private Vector3 _length;

        private void Start()
        {
            SetStartPosition();
            SetLength();
        }

        private void Update()
        {
            PassiveMove();
        }

        private void SetStartPosition()
        {
            transform.position = new Vector3(0, 0, 0);
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