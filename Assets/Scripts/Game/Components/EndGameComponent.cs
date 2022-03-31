using UnityEngine;
using Base.Component;

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

        private const string ScoreText = "Score";
        private const string GoldPrefixText = "+";
        private const string NewHighScoreText = "New High Score";
        private const string SavePlanetText = "You Saved The ";
        private const string NeedYourHelpText = " Need Your Help";

        private DataComponent _dataComponent;
        private MainMenuComponent _mainMenuComponent;
        private InGameComponent _inGameComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
            _mainMenuComponent = componentContainer.GetComponent("MainMenuComponent") as MainMenuComponent;
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
                OnScoreChange?.Invoke(NewHighScoreText, highScore.ToString());
            else
                OnScoreChange?.Invoke(ScoreText, lastScore.ToString());
        }

        private void ChangeGold()
        {
            string ownedCoin = _dataComponent.GoldData.ownedGold.ToString();
            string lastGainedCoin = GoldPrefixText + _inGameComponent.LastGainedGold;

            OnGoldChange?.Invoke(ownedCoin, lastGainedCoin);
        }

        private void SetPlanetStatus()
        {
            bool isPlanetSaved = _inGameComponent.IsPlanetSaved;
            string selectedPlanet = _mainMenuComponent.GetSelectedPlanetName();

            if (isPlanetSaved)
            {
                string savePlanetText = SavePlanetText + selectedPlanet;
                OnSavePlanetChange?.Invoke(savePlanetText);
                OnWin?.Invoke();
            }
            else
            {
                string needYourHelpText = selectedPlanet + NeedYourHelpText;
                OnNeedYourHelpChange?.Invoke(needYourHelpText);
                OnLose?.Invoke();
            }
        }

        #endregion
    }
}