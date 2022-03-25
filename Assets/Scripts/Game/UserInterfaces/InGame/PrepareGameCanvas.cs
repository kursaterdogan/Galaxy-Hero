using UnityEngine;
using Base.UserInterface;
using Game.UserInterfaces.Splash;
using TMPro;

namespace Game.UserInterfaces.InGame
{
    public class PrepareGameCanvas : BaseCanvas, IStartable, IQuittable
    {
        [SerializeField] private LoadingIcon loadingIcon;

        [SerializeField] private TMP_Text highScoreAmountText;
        [SerializeField] private TMP_Text selectedSuperPowerText;

        public void OnStart()
        {
            //TODO Handle PrepareGameCanvas
            EnableLoadingIcon();
            PlayLoadingIconAnimation();
        }

        public void OnQuit()
        {
            StopLoadingIconAnimation();
            DisableLoadingIcon();
        }

        public void SetHighScoreAmountText(string highScore)
        {
            highScoreAmountText.text = highScore;
        }

        public void SetSelectedSuperPowerText(string superPower)
        {
            selectedSuperPowerText.text = superPower;
        }

        private void EnableLoadingIcon()
        {
            loadingIcon.gameObject.SetActive(true);
        }

        private void DisableLoadingIcon()
        {
            loadingIcon.gameObject.SetActive(false);
        }

        private void PlayLoadingIconAnimation()
        {
            loadingIcon.PlayLoadingAnimation();
        }

        private void StopLoadingIconAnimation()
        {
            loadingIcon.StopLoadingAnimation();
        }
    }
}