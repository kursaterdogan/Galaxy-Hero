using UnityEngine;

namespace Game.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public delegate void GameManagerChangeDelegate(int value);

        public event GameManagerChangeDelegate OnScoreChange;
        public event GameManagerChangeDelegate OnHealthChange;

        public delegate void GameManagerPlanetChangeDelegate();

        public event GameManagerPlanetChangeDelegate OnPlanetSave;
        public event GameManagerPlanetChangeDelegate OnGameComplete;

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
            OnHealthChange?.Invoke(health);
        }

        public void SavePlanet()
        {
            OnPlanetSave?.Invoke();
            OnGameComplete?.Invoke();
        }

        public void CompleteGame()
        {
            OnGameComplete?.Invoke();
        }
    }
}