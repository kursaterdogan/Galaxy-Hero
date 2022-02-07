using System.Collections;
using UnityEngine;
using Base.UserInterface;

namespace Game.UserInterfaces.Splash
{
    public class SplashCanvas : BaseCanvas
    {
        [SerializeField] private Logo appLogo;
        [SerializeField] private LoadingIcon loadingIcon;

        private const float AnimationTime = 1.0f;
        private bool _isIntroAnimCompleted;

        public void PlayIntroAnimation()
        {
            StartCoroutine(IntroAnimation());
        }

        public bool IsIntroCompleted()
        {
            return _isIntroAnimCompleted;
        }

        private IEnumerator IntroAnimation()
        {
            appLogo.gameObject.SetActive(true);

            appLogo.PlayFadeInAnimation(AnimationTime);
            yield return new WaitForSeconds(AnimationTime);

            appLogo.PlayFadeOutAnimation(AnimationTime);
            yield return new WaitForSeconds(AnimationTime);

            _isIntroAnimCompleted = true;

            loadingIcon.gameObject.SetActive(true);
            loadingIcon.PlayLoadingAnimation();
        }
    }
}