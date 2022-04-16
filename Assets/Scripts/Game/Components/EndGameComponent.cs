using UnityEngine;
using Base.Component;
using Game.Enums;

namespace Game.Components
{
    public class EndGameComponent : MonoBehaviour, IComponent, IConstructable
    {
        public delegate void EndGameChangeDelegate();

        public event EndGameChangeDelegate OnWin;
        public event EndGameChangeDelegate OnLose;

        public delegate void EndGamePlanetStatusChangeDelegate(string text);

        public event EndGamePlanetStatusChangeDelegate OnSavePlanetChange;
        public event EndGamePlanetStatusChangeDelegate OnNeedYourHelpChange;

        public delegate void EndGameTextChangeDelegate(string txt, string text);

        public event EndGameTextChangeDelegate OnScoreChange;
        public event EndGameTextChangeDelegate OnGoldChange;

        private const string _scoreText = "Score";
        private const string _goldPrefixText = "+";
        private const string _newHighScoreText = "New High Score";
        private const string _savePlanetText = "You Saved The ";
        private const string _needYourHelpText = " Need Your Help";

        private DataComponent _dataComponent;
        private InGameComponent _inGameComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
            _inGameComponent = componentContainer.GetComponent("InGameComponent") as InGameComponent;
        }

        public void OnConstruct()
        {
            ChangeScore();
            ChangeGold();
            SetPlanetStatus();
        }

        #region Changes

        private void ChangeScore()
        {
            bool isHighScore = _inGameComponent.IsHighScore;
            int highScore = _dataComponent.AchievementData.highScore;
            int lastScore = _inGameComponent.LastScore;

            if (isHighScore)
                OnScoreChange?.Invoke(_newHighScoreText, highScore.ToString());
            else
                OnScoreChange?.Invoke(_scoreText, lastScore.ToString());
        }

        private void ChangeGold()
        {
            string ownedCoin = _dataComponent.GoldData.ownedGold.ToString();
            string lastGainedCoin = _goldPrefixText + _inGameComponent.LastGainedGold;

            OnGoldChange?.Invoke(ownedCoin, lastGainedCoin);
        }

        private void SetPlanetStatus()
        {
            bool isPlanetSaved = _inGameComponent.IsPlanetSaved;
            string selectedPlanet = ((Planet)_dataComponent.PlanetData.selectedPlanet).ToString();

            if (isPlanetSaved)
            {
                string savePlanetText = _savePlanetText + selectedPlanet;
                OnSavePlanetChange?.Invoke(savePlanetText);
                OnWin?.Invoke();
            }
            else
            {
                string needYourHelpText = selectedPlanet + _needYourHelpText;
                OnNeedYourHelpChange?.Invoke(needYourHelpText);
                OnLose?.Invoke();
            }
        }

        #endregion
    }
}