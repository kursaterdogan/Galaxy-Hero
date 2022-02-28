using UnityEngine;
using Base.UserInterface;

namespace Game.UserInterfaces.Splash
{
    public class SplashCanvas : BaseCanvas
    {
        [SerializeField] private Logo logo;
        [SerializeField] private LoadingIcon loadingIcon;

        public void PlayLogoFadeInAnimation(float animationTime)
        {
            logo.gameObject.SetActive(true);
            logo.PlayFadeInAnimation(animationTime);
        }

        public void PlayLogoFadeOutAnimation(float animationTime)
        {
            logo.PlayFadeOutAnimation(animationTime);
        }

        public void PlayLoadingIconAnimation()
        {
            loadingIcon.gameObject.SetActive(true);
            loadingIcon.PlayLoadingAnimation();
        }

        public void StopLoadingIconAnimation()
        {
            loadingIcon.StopLoadingAnimation();
        }

        public void DisableObjects()
        {
            logo.gameObject.SetActive(false);
            loadingIcon.gameObject.SetActive(false);
        }
    }
}