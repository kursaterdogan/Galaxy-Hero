using System.Collections;
using UnityEngine;
using Base.UserInterface;

namespace Game.UserInterfaces.Splash
{
    public class SplashCanvas : BaseCanvas
    {
        public delegate void SplashRequestDelegate();

        public event SplashRequestDelegate OnIntroAnimationRequest;
        public event SplashRequestDelegate OnLoadingAnimationRequest;

        [SerializeField] private Logo logo;
        [SerializeField] private LoadingIcon loadingIcon;

        private const float AnimationTime = 1.0f;

        public void PlayIntroAnimation()
        {
            StartCoroutine(IntroAnimation());
        }

        private IEnumerator IntroAnimation()
        {
            logo.gameObject.SetActive(true);
            logo.PlayFadeInAnimation(AnimationTime);
            yield return new WaitForSeconds(AnimationTime);
            logo.PlayFadeOutAnimation(AnimationTime);

            RequestIntroAnimation();

            loadingIcon.gameObject.SetActive(true);
            loadingIcon.PlayLoadingAnimation();
            yield return new WaitForSeconds(AnimationTime);
            loadingIcon.StopLoadingAnimation();

            RequestLoadingAnimation();

            logo.gameObject.SetActive(false);
            loadingIcon.gameObject.SetActive(false);
        }

        private void RequestIntroAnimation()
        {
            OnIntroAnimationRequest?.Invoke();
        }

        private void RequestLoadingAnimation()
        {
            OnLoadingAnimationRequest?.Invoke();
        }
    }
}