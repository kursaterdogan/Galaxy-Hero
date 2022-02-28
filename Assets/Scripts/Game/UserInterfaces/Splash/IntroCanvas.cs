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
            loadingIcon.gameObject.SetActive(true);
            logo.gameObject.SetActive(true);
        }

        public void OnQuit()
        {
            loadingIcon.gameObject.SetActive(false);
            logo.gameObject.SetActive(false);
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
    }
}