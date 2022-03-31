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

        private int _scoreMultiplier;
        private int _score;
        private int _health;

        public void SetScoreMultiplier(int scoreMultiplier)
        {
            _scoreMultiplier = scoreMultiplier;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

        public void IncreaseScore(int score)
        {
            _score += score * _scoreMultiplier;
            ChangeScore();
        }

        public void DecreaseHealth()
        {
            _health -= 1;
            ChangeHealth();
        }

        private void ChangeScore()
        {
            OnScoreChange?.Invoke(_score);
        }

        private void ChangeHealth()
        {
            OnHealthChange?.Invoke(_health);
        }

        private void SavePlanet()
        {
            OnPlanetSave?.Invoke();
        }
    }
}