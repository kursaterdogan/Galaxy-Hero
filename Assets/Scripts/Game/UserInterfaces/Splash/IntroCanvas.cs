using UnityEngine;
using Base.UserInterface;

namespace Game.UserInterfaces.Splash
{
    public class IntroCanvas : BaseCanvas, IStartable, IQuittable
    {
        [SerializeField] private Logo logo;
        [SerializeField] private LoadingIcon loadingIcon;

        public void OnStart()
        {
            EnableLoadingIcon();
            EnableLogo();
        }

        public void OnQuit()
        {
            DisableLogo();
            DisableLoadingIcon();
        }

        public void PlayLogoFadeOutAnimation(float animationTime)
        {
            logo.PlayFadeOutAnimation(animationTime);
        }

        public void PlayLoadingIconAnimation()
        {
            loadingIcon.PlayLoadingAnimation();
        }

        public void StopLoadingIconAnimation()
        {
            loadingIcon.StopLoadingAnimation();
        }

        private void EnableLogo()
        {
            logo.gameObject.SetActive(true);
        }

        private void EnableLoadingIcon()
        {
            loadingIcon.gameObject.SetActive(true);
        }

        private void DisableLogo()
        {
            logo.gameObject.SetActive(false);
        }

        private void DisableLoadingIcon()
        {
            loadingIcon.gameObject.SetActive(false);
        }
    }
}