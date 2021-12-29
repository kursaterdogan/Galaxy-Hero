namespace Game.Gameplay
{
    using UnityEngine;

    public class ParallaxBackground : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        [SerializeField] private float speed;
        private float _length;

        private void Start()
        {
            SetLength();
        }

        private void Update()
        {
            TriggerEffect();
        }

        private void SetLength()
        {
            _length = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        private void TriggerEffect()
        {
            if (transform.position.y < -_length)
                transform.position += new Vector3(0, _length, 0);

            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
    }
}