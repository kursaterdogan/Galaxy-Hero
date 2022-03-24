using System.Collections;
using UnityEngine;

namespace Game.UserInterfaces.Splash
{
    public class LoadingIcon : MonoBehaviour
    {
        [SerializeField] private Transform rectTransform;

        private readonly Vector3 _rotationVector = new Vector3(0, 0, -60);

        public void PlayLoadingAnimation()
        {
            StartCoroutine(RotateAnimation());
        }

        public void StopLoadingAnimation()
        {
            StopCoroutine(RotateAnimation());
        }

        private IEnumerator RotateAnimation()
        {
            while (true)
            {
                rectTransform.Rotate(Time.deltaTime * _rotationVector);
                yield return null;
            }
        }
    }
}