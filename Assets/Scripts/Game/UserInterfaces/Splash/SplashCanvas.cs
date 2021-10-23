namespace Game.UserInterfaces.Splash
{
    using Base.UserInterface;
    using System.Collections;
    using UnityEngine;

    public class SplashCanvas : BaseCanvas
    {
        [SerializeField] private Logo appLogo;
        [SerializeField] private LoadingIcon loadingIcon;

        private const float AnimationTime = 1.0f;

        private bool _isIntroAnimCompleted;

        protected override void Init()
        {
            if (appLogo == null)
                Debug.LogError("AppLogo reference is null");
            if (loadingIcon == null)
                Debug.LogError("LoadingIcon reference is null");
        }

        public void PlayIntroAnimation()
        {
            StartCoroutine(IntroAnimation());
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

        public bool IsIntroCompleted()
        {
            return _isIntroAnimCompleted;
        }
    }
}