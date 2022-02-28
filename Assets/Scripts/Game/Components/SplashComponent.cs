using UnityEngine;
using System.Collections;
using Base.Component;

namespace Game.Components
{
    public class SplashComponent : MonoBehaviour, IComponent, IStartable
    {
        public delegate void SplashChangeDelegate();

        public event SplashChangeDelegate OnLogoAnimationStart;
        public event SplashChangeDelegate OnLogoAnimationComplete;
        public event SplashChangeDelegate OnLoadingIconAnimationStart;
        public event SplashChangeDelegate OnLoadingIconAnimationComplete;
        public event SplashChangeDelegate OnSplashComplete;

        private float animationTime = 1.0f;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>SplashComponent initialized!</color>");
        }

        public void CallStart()
        {
            StartCoroutine(SplashAnimation());
        }

        public float GetAnimationTime()
        {
            return animationTime;
        }

        private IEnumerator SplashAnimation()
        {
            OnLogoAnimationStart?.Invoke();

            yield return new WaitForSeconds(animationTime);

            OnLogoAnimationComplete?.Invoke();
            OnLoadingIconAnimationStart?.Invoke();

            yield return new WaitForSeconds(animationTime);

            OnLoadingIconAnimationComplete?.Invoke();
            OnSplashComplete?.Invoke();
        }
    }
}