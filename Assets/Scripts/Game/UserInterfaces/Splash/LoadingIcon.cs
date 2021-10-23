namespace Game.UserInterfaces.Splash
{
    using Base.UserInterface;
    using System.Collections;
    using UnityEngine;

    public class LoadingIcon : MonoBehaviour, ICanvasObject
    {
        private Vector3 _rotationVector = new Vector3(0, 0, -60);
        private Transform _iconTransform;

        public void Init()
        {
        }

        public void Activate()
        {
        }

        public void Deactivate()
        {
            StopCoroutine(RotateAnimation());
        }

        public void PlayLoadingAnimation()
        {
            StartCoroutine(RotateAnimation());
        }

        private IEnumerator RotateAnimation()
        {
            if (_iconTransform == null)
            {
                _iconTransform = GetComponent<Transform>();
            }

            while (true)
            {
                _iconTransform.Rotate(Time.deltaTime * _rotationVector);
                yield return null;
            }
        }
    }
}