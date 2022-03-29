using UnityEngine;

namespace Game.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public delegate void GameManagerChangeDelegate(int value);

        public event GameManagerChangeDelegate OnScoreChange;
        public event GameManagerChangeDelegate OnHealthChange;
        public event GameManagerChangeDelegate OnLastScoreChange;

        public delegate void GameManagerSaveDelegate();

        public event GameManagerSaveDelegate OnPlanetSave;

        private int _scoreMultiplier;
        private int _score;
        private int _health;

        void OnDestroy()
        {
            ChangeLastScore();
        }

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
            ChangeScore(_score);
        }

        public void DecreaseHealth()
        {
            _health -= 1;
            ChangeHealth();
        }

        private void ChangeScore(int score)
        {
            OnScoreChange?.Invoke(score);
        }

        private void ChangeHealth()
        {
            OnHealthChange?.Invoke(_health);
        }

        private void ChangeLastScore()
        {
            OnLastScoreChange?.Invoke(_score);
        }

        private void SavePlanet()
        {
            OnPlanetSave?.Invoke();
        }
    }
}