using UnityEngine;
using Base.UserInterface;
using TMPro;

namespace Game.UserInterfaces.InGame
{
    public class EndGameCanvas : BaseCanvas, IStartable
    {
        public delegate void EndGameRequestDelegate();

        public event EndGameRequestDelegate OnReturnToMainRequest;

        [SerializeField] private TMP_Text congratulationsText;
        [SerializeField] private TMP_Text savePlanetText;
        [SerializeField] private TMP_Text missionFailedText;
        [SerializeField] private TMP_Text needYourHelpText;

        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text scoreAmountText;
        [SerializeField] private TMP_Text ownedGoldText;
        [SerializeField] private TMP_Text lastGainedGoldText;

        public void OnStart()
        {
            DisableCongratulationsText();
            DisableSavePlanetText();
            DisableMissionFailedText();
            DisableNeedYourHelpText();
        }

        #region Changes

        public void ChangeScore(string score, string scoreAmount)
        {
            scoreText.text = score;
            scoreAmountText.text = scoreAmount;
        }

        public void ChangeGold(string ownedGold, string lastGainedGold)
        {
            ownedGoldText.text = ownedGold;
            lastGainedGoldText.text = lastGainedGold;
        }

        public void ChangeSavePlanetText(string savePlanet)
        {
            savePlanetText.text = savePlanet;
        }

        public void ChangeNeedYourHelpText(string needYourHelp)
        {
            needYourHelpText.text = needYourHelp;
        }

        public void EnableWinObjects()
        {
            congratulationsText.enabled = true;
            savePlanetText.enabled = true;
        }

        public void EnableLoseObjects()
        {
            missionFailedText.enabled = true;
            needYourHelpText.enabled = true;
        }

        #endregion

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainRequest?.Invoke();
        }

        private void DisableCongratulationsText()
        {
            if (congratulationsText.enabled)
                congratulationsText.enabled = false;
        }

        private void DisableSavePlanetText()
        {
            if (savePlanetText.enabled)
                savePlanetText.enabled = false;
        }

        private void DisableMissionFailedText()
        {
            if (missionFailedText.enabled)
                missionFailedText.enabled = false;
        }

        private void DisableNeedYourHelpText()
        {
            if (needYourHelpText.enabled)
                needYourHelpText.enabled = false;
        }
    }
}