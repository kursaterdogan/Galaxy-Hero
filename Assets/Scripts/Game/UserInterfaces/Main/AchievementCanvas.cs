using UnityEngine;
using Base.UserInterface;
using TMPro;

namespace Game.UserInterfaces.Main
{
    public class AchievementCanvas : BaseCanvas
    {
        public delegate void AchievementRequestDelegate();

        public event AchievementRequestDelegate OnReturnToMainMenuRequest;

        [SerializeField] private GameObject needHelpText;
        [SerializeField] private GameObject oCaptainMyCaptainText;
        [SerializeField] private TMP_Text highScoreAmountText;

        public void ChangeHighScore(string highScore)
        {
            highScoreAmountText.text = highScore;
        }

        public void ActivateNeedHelpText()
        {
            needHelpText.SetActive(true);
        }

        public void ActivateOCaptainMyCaptainText()
        {
            oCaptainMyCaptainText.SetActive(true);
        }
        
        public void DeactivateNeedHelpText()
        {
            needHelpText.SetActive(false);
        }

        public void DeactivateOCaptainMyCaptainText()
        {
            oCaptainMyCaptainText.SetActive(false);
        }

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}