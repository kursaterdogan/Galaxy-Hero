namespace Game.Gameplay
{
    using UnityEngine;

    public class ParallaxBackground : MonoBehaviour
    {
        //TODO Integrate with StateMachine
        [SerializeField] private float speed;
        private Transform _gameCameraTransform;
        private float _startPosition, _length, _temp, _distance;

        private void Start()
        {
            SetGameCameraPosition();
            SetStartPosition();
            SetLength();
        }

        public void Update()
        {
            TriggerEffect();
        }

        private void SetGameCameraPosition()
        {
            _gameCameraTransform = FindObjectOfType<GameCamera>().GetTransform();
        }

        private void SetStartPosition()
        {
            _startPosition = _gameCameraTransform.position.y;
        }

        private void SetLength()
        {
            _length = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        private void TriggerEffect()
        {
            var position = _gameCameraTransform.position;
            _temp = position.y * (1 - speed);
            _distance = position.y * speed;

            transform.position = new Vector3(0, _startPosition + _distance, 0);

            if (_temp > _startPosition + _length)
                _startPosition += _length;
            else if (_temp < _startPosition - _length)
                _startPosition -= _length;
        }
    }
}