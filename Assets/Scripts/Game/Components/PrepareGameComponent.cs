using UnityEngine;
using System.Collections;
using Base.Component;

namespace Game.Components
{
    public class PrepareGameComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void PrepareGameChangeDelegate();

        public event PrepareGameChangeDelegate OnLoadingComplete;

        public delegate void PrepareGameTextChangeDelegate(string text);

        public event PrepareGameTextChangeDelegate OnHighScoreChange;
        public event PrepareGameTextChangeDelegate OnSuperPowerChange;

        private const float AnimationTime = 0.5f;

        private DataComponent _dataComponent;
        private SuperPowerComponent _superPowerComponent;
        private InGameComponent _inGameComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
            _superPowerComponent = componentContainer.GetComponent("SuperPowerComponent") as SuperPowerComponent;
            _inGameComponent = componentContainer.GetComponent("InGameComponent") as InGameComponent;
        }

        public void OnConstruct()
        {
            ChangeHighScore();
            ChangeSuperPower();
            StartCoroutine(LoadGame());
        }

        public void OnDestruct()
        {
            StopCoroutine(LoadGame());
        }

        #region Changes

        private void ChangeHighScore()
        {
            string highScore = _dataComponent.AchievementData.highScore.ToString();
            OnHighScoreChange?.Invoke(highScore);
        }

        private void ChangeSuperPower()
        {
            string superPower = _superPowerComponent.GetSelectedSuperPower().ToString();
            OnSuperPowerChange?.Invoke(superPower);
        }

        #endregion

        private IEnumerator LoadGame()
        {
            _inGameComponent.SetUpGame();

            yield return new WaitForSeconds(AnimationTime);

            OnLoadingComplete?.Invoke();
        }
    }
}