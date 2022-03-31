using UnityEngine;

namespace Game.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public delegate void GameManagerChangeDelegate(int value);

        public event GameManagerChangeDelegate OnScoreChange;
        public event GameManagerChangeDelegate OnHealthChange;

        public delegate void GameManagerSaveDelegate();

        public event GameManagerSaveDelegate OnPlanetSave;

        public static GameManager SharedInstance;

        private int _scoreMultiplier;
        private int _score;

        private void Start()
        {
            SharedInstance = this;
        }

        public void SetScoreMultiplier(int scoreMultiplier)
        {
            _scoreMultiplier = scoreMultiplier;
        }

        public void IncreaseScore(int score)
        {
            _score += score * _scoreMultiplier;
            OnScoreChange?.Invoke(_score);
        }

        public void DecreaseHealth(int health)
        {
            //TODO Death
            OnHealthChange?.Invoke(health);
        }

        private void SavePlanet()
        {
            //TODO Win
            OnPlanetSave?.Invoke();
        }
    }
}