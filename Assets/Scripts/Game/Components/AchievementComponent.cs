using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class AchievementComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void AchievementGalaxyStatusChangeDelegate();

        public event AchievementGalaxyStatusChangeDelegate OnOCaptainMyCaptainActivate;
        public event AchievementGalaxyStatusChangeDelegate OnNeedHelpActivate;
        public event AchievementGalaxyStatusChangeDelegate OnOCaptainMyCaptainDeactivate;
        public event AchievementGalaxyStatusChangeDelegate OnNeedHelpDeactivate;

        public delegate void AchievementHighScoreChangeDelegate(string highScore);

        public event AchievementHighScoreChangeDelegate OnHighScoreChange;

        private DataComponent _dataComponent;

        private bool _isGalaxySaved;
        private string _highScore;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
        }

        public void OnConstruct()
        {
            SetHighScore();
            SetIsGalaxySaved();

            ChangeHighScore();
            ActivateGalaxyStatus();
        }

        public void OnDestruct()
        {
            DeactivateGalaxyStatus();
        }

        #region Changes

        private void ChangeHighScore()
        {
            OnHighScoreChange?.Invoke(_highScore);
        }

        private void ActivateGalaxyStatus()
        {
            if (_isGalaxySaved)
                OnOCaptainMyCaptainActivate?.Invoke();
            else
                OnNeedHelpActivate?.Invoke();
        }

        private void DeactivateGalaxyStatus()
        {
            if (_isGalaxySaved)
                OnOCaptainMyCaptainDeactivate?.Invoke();
            else
                OnNeedHelpDeactivate?.Invoke();
        }

        #endregion

        private void SetIsGalaxySaved()
        {
            _isGalaxySaved = _dataComponent.InventoryData.isSaturnSaved && _dataComponent.InventoryData.isMarsSaved;
        }

        private void SetHighScore()
        {
            _highScore = _dataComponent.AchievementData.highScore.ToString();
        }
    }
}