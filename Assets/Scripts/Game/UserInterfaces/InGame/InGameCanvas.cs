using UnityEngine;
using UnityEngine.UI;
using Base.UserInterface;
using TMPro;

namespace Game.UserInterfaces.InGame
{
    public class InGameCanvas : BaseCanvas, IStartable
    {
        public delegate void InGameRequestDelegate();

        public event InGameRequestDelegate OnReturnToMainMenuRequest;

        private const string _defaultScoreValue = "0";
        [SerializeField] private TMP_Text scoreText;

        [SerializeField] private GameObject[] healthLevels;
        [SerializeField] private Image[] currentHealthLevels;

        public void OnStart()
        {
            ResetScoreText();
            ResetHealthLevels();
            ResetCurrentHealthLevels();
        }

        public void SetHealthLevels(int healthLevel)
        {
            for (int i = 0; i < healthLevel; i++)
            {
                if (!healthLevels[i].activeInHierarchy)
                    healthLevels[i].SetActive(true);
            }
        }

        public void SetCurrentHealthLevel(int currentHealthLevel)
        {
            ResetCurrentHealthLevels();

            for (int i = 0; i < currentHealthLevel; i++)
            {
                currentHealthLevels[i].enabled = true;
            }
        }

        public void ChangeScore(string score)
        {
            scoreText.text = score;
        }

        public void RequestReturnToMainMenu()
        {
            OnReturnToMainMenuRequest?.Invoke();
        }

        private void ResetHealthLevels()
        {
            foreach (GameObject healthLevel in healthLevels)
            {
                if (healthLevel.activeInHierarchy)
                    healthLevel.SetActive(false);
            }
        }

        private void ResetCurrentHealthLevels()
        {
            foreach (Image currentHealthLevel in currentHealthLevels)
            {
                if (currentHealthLevel.enabled)
                    currentHealthLevel.enabled = false;
            }
        }

        private void ResetScoreText()
        {
            scoreText.text = _defaultScoreValue;
        }
    }
}