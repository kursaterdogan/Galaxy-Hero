using UnityEngine;
using Base.Component;
using Game.Enums;
using Game.Gameplay;
using Game.Gameplay.Enemy;
using Game.Gameplay.Player;

namespace Game.Components
{
    public class InGameComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void InGameScoreChangeDelegate(string score);

        public event InGameScoreChangeDelegate OnScoreChange;

        public delegate void InGameHealthLevelChangeDelegate(int level);

        public event InGameHealthLevelChangeDelegate OnHealthLevelChange;
        public event InGameHealthLevelChangeDelegate OnCurrentHealthLevelChange;

        private const int _saturnGiftGoldGainMultiplier = 2;
        private const int _marsGiftScoreGainMultiplier = 2;
        private const float _fireRateDividend = 1.2f;
        private const float _speedMultiplier = 3f;

        public int LastScore { get; private set; }
        public int LastGainedGold { get; private set; }
        public bool IsHighScore { get; private set; }
        public bool IsPlanetSaved { get; private set; }

        [SerializeField] private GameManager gameManagerPrefab;
        [SerializeField] private GameObject[] parallaxBackgroundPrefabs;
        [SerializeField] private EnemySpawner[] enemySpawnerPrefabs;
        [SerializeField] private PlayerProjectilePool playerProjectilePoolPrefab;
        [SerializeField] private Player playerPrefab;

        [SerializeField] private GameCamera gameCamera;
        private GameManager _gameManager;
        private GameObject _parallaxBackground;
        private EnemySpawner _enemySpawner;
        private PlayerProjectilePool _playerProjectilePool;
        private Player _player;

        private float _superPowerDuration;

        private DataComponent _dataComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
            SuperPowerComponent superPowerComponent =
                componentContainer.GetComponent("SuperPowerComponent") as SuperPowerComponent;

            _superPowerDuration = superPowerComponent.GetSuperPowerDuration();
        }

        public void OnConstruct()
        {
            ResetLastScore();
            ResetLastGainedGold();
            ResetIsHighScore();
            ResetIsPlanetSaved();

            SetHealthLevel();

            //TODO Handle HealthLevel
            // ChangeCurrentHealthLevel(4);

            LaunchGame();
        }

        public void OnDestruct()
        {
            DestroyGame();

            SaveAchievementData();
            SaveGoldData();
            SaveInventoryData();
        }

        public void SetUpGame()
        {
            SetUpGameManager();
            SetUpParallaxBackground();
            SetUpEnemySpawner();
            SetUpPlayerProjectilePool();
            SetUpPlayer();
        }

        #region Changes

        private void SetHealthLevel()
        {
            int healthLevel = _dataComponent.GarageData.healthLevel;
            OnHealthLevelChange?.Invoke(healthLevel);
            OnCurrentHealthLevelChange?.Invoke(healthLevel);
        }

        private void ChangeCurrentHealthLevel(int currentHealthLevel)
        {
            OnCurrentHealthLevelChange?.Invoke(currentHealthLevel);
        }

        private void ChangeScore(int score)
        {
            LastScore = score;
            OnScoreChange?.Invoke(score.ToString());
        }

        private void ChangeIsPlanetSaved()
        {
            IsPlanetSaved = true;
        }

        #endregion

        private void LaunchGame()
        {
            _enemySpawner.OnLaunch();
            _player.OnLaunch();
        }

        private void DestroyGame()
        {
            Destroy(_player.gameObject);
            Destroy(_enemySpawner.gameObject);
            Destroy(_playerProjectilePool.gameObject);
            Destroy(_parallaxBackground.gameObject);
            Destroy(_gameManager.gameObject);
        }

        private void SetUpGameManager()
        {
            _gameManager = Instantiate(gameManagerPrefab);

            bool isMarsSaved = _dataComponent.InventoryData.isMarsSaved;
            if (isMarsSaved)
            {
                int scoreMultiplierLevel = _dataComponent.GarageData.scoreMultiplierLevel;
                _gameManager.SetScoreMultiplier(scoreMultiplierLevel);
            }
            else
            {
                int scoreMultiplierLevel =
                    _dataComponent.GarageData.scoreMultiplierLevel * _marsGiftScoreGainMultiplier;
                _gameManager.SetScoreMultiplier(scoreMultiplierLevel);
            }

            _gameManager.OnScoreChange += ChangeScore;
            _gameManager.OnHealthChange += ChangeCurrentHealthLevel;
            _gameManager.OnPlanetSave += ChangeIsPlanetSaved;
        }

        private void SetUpParallaxBackground()
        {
            int selectedPlanet = _dataComponent.PlanetData.selectedPlanet;
            _parallaxBackground = Instantiate(parallaxBackgroundPrefabs[selectedPlanet]);
        }

        private void SetUpEnemySpawner()
        {
            int selectedSpawner = _dataComponent.PlanetData.selectedPlanet;
            _enemySpawner = Instantiate(enemySpawnerPrefabs[selectedSpawner]);
        }

        private void SetUpPlayerProjectilePool()
        {
            _playerProjectilePool = Instantiate(playerProjectilePoolPrefab);

            float maxVerticalPosition = gameCamera.GetMaxVerticalPosition();
            _playerProjectilePool.SetMaxVerticalPosition(maxVerticalPosition);
        }

        private void SetUpPlayer()
        {
            _player = Instantiate(playerPrefab);

            int healthLevel = _dataComponent.GarageData.healthLevel;
            _player.SetHealth(healthLevel);

            float speed = _speedMultiplier * _dataComponent.GarageData.speedLevel;
            _player.SetSpeed(speed);

            float fireRate = _fireRateDividend / _dataComponent.GarageData.fireRateLevel;
            _player.SetFireDuration(fireRate);

            int cannonLevel = _dataComponent.GarageData.cannonLevel - 1;
            _player.SetCannonLevel(cannonLevel);

            SuperPower superPower = (SuperPower)_dataComponent.SuperPowerData.selectedSuperPower;
            _player.SetActiveSuperPower(superPower);

            _player.SetSuperPowerDuration(_superPowerDuration);

            float shildeoDuration = _dataComponent.GarageData.shildeoLevel;
            _player.SetShildeoDuration(shildeoDuration);

            float bombeoDuration = _dataComponent.GarageData.bombeoLevel;
            _player.SetBombeoDuration(bombeoDuration);

            float ghosteoDuration = _dataComponent.GarageData.ghosteoLevel;
            _player.SetGhosteoDuration(ghosteoDuration);
        }

        private void ResetLastScore()
        {
            LastScore = 0;
        }

        private void ResetLastGainedGold()
        {
            LastGainedGold = 0;
        }

        private void ResetIsHighScore()
        {
            IsHighScore = false;
        }

        private void ResetIsPlanetSaved()
        {
            IsPlanetSaved = false;
        }

        private void SaveAchievementData()
        {
            int highScore = _dataComponent.AchievementData.highScore;

            if (highScore >= LastScore)
                return;

            IsHighScore = true;
            _dataComponent.AchievementData.highScore = LastScore;
            _dataComponent.SaveAchievementData();
        }

        private void SaveGoldData()
        {
            int goldMultiplierLevel = _dataComponent.GarageData.goldMultiplierLevel;

            int gainedGold;
            bool isSaturnSaved = _dataComponent.InventoryData.isSaturnSaved;
            if (isSaturnSaved)
            {
                gainedGold = LastScore * goldMultiplierLevel * _saturnGiftGoldGainMultiplier;
                LastGainedGold = gainedGold;
            }
            else
            {
                gainedGold = LastScore * goldMultiplierLevel;
                LastGainedGold = gainedGold;
            }

            _dataComponent.GoldData.ownedGold += gainedGold;
            _dataComponent.SaveGoldData();
        }

        private void SaveInventoryData()
        {
            if (!IsPlanetSaved)
                return;

            Planet planet = (Planet)_dataComponent.PlanetData.selectedPlanet;

            switch (planet)
            {
                case Planet.Saturn when !_dataComponent.InventoryData.isSaturnSaved:
                    _dataComponent.InventoryData.isSaturnSaved = true;
                    _dataComponent.SaveInventoryData();
                    break;
                case Planet.Mars when !_dataComponent.InventoryData.isMarsSaved:
                    _dataComponent.InventoryData.isMarsSaved = true;
                    _dataComponent.SaveInventoryData();
                    break;
            }
        }
    }
}