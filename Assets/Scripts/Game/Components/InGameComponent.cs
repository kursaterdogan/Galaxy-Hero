using UnityEngine;
using Base.Component;
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

        private const int SaturnGiftGoldGainMultiplier = 2;
        private const int MarsGiftScoreGainMultiplier = 2;
        private const float FireRateDividend = 1.2f;
        private const float SpeedMultiplier = 3f;

        public int LastScore => _lastScore;
        public int LastGainedCoin => _lastGainedCoin;
        public bool IsPlanetSaved => _isPlanetSaved;

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

        private bool _isPlanetSaved;
        private int _lastScore;
        private int _lastGainedCoin;

        private DataComponent _dataComponent;
        private MainMenuComponent _mainMenuComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
            _mainMenuComponent = componentContainer.GetComponent("MainMenuComponent") as MainMenuComponent;
        }

        public void OnConstruct()
        {
            SetIsPlanetSaved();
            SetHealthLevel();

            //TODO Handle HealthLevel
            // ChangeCurrentHealthLevel(4);

            LaunchGame();
        }

        public void OnDestruct()
        {
            DestroyGame();

            SaveAchievementData();
            SaveCoinData();
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
            OnScoreChange?.Invoke(score.ToString());
        }

        private void ChangeLastScore(int score)
        {
            _lastScore = score;
        }

        private void ChangeIsPlanetSaved()
        {
            _isPlanetSaved = true;
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
                    _dataComponent.GarageData.scoreMultiplierLevel * MarsGiftScoreGainMultiplier;
                _gameManager.SetScoreMultiplier(scoreMultiplierLevel);
            }

            int healthLevel = _dataComponent.GarageData.healthLevel;
            _gameManager.SetHealth(healthLevel);

            _gameManager.OnScoreChange += ChangeScore;
            _gameManager.OnHealthChange += ChangeCurrentHealthLevel;
            _gameManager.OnLastScoreChange += ChangeLastScore;
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

            _player.SetGameCamera(gameCamera);
            _player.SetPlayerProjectilePool(_playerProjectilePool);

            float speed = SpeedMultiplier * _dataComponent.GarageData.speedLevel;
            _player.SetSpeed(speed);

            float fireRate = FireRateDividend / _dataComponent.GarageData.fireRateLevel;
            _player.SetFireRate(fireRate);

            int cannonLevel = _dataComponent.GarageData.cannonLevel - 1;
            _player.SetCannonLevel(cannonLevel);
        }

        private void SetIsPlanetSaved()
        {
            _isPlanetSaved = false;
        }

        private void SaveAchievementData()
        {
            int highScore = _dataComponent.AchievementData.highScore;

            if (highScore > _lastScore)
                return;

            _dataComponent.AchievementData.highScore = _lastScore;
            _dataComponent.SaveAchievementData();
        }

        private void SaveCoinData()
        {
            int goldMultiplierLevel = _dataComponent.GarageData.goldMultiplierLevel;

            int gainedGold;
            bool isSaturnSaved = _dataComponent.InventoryData.isSaturnSaved;
            if (isSaturnSaved)
            {
                gainedGold = _lastScore * goldMultiplierLevel * SaturnGiftGoldGainMultiplier;
                _lastGainedCoin = gainedGold;
            }
            else
            {
                gainedGold = _lastScore * goldMultiplierLevel;
                _lastGainedCoin = gainedGold;
            }

            _dataComponent.CoinData.ownedCoin += gainedGold;
            _dataComponent.SaveCoinData();
        }

        private void SaveInventoryData()
        {
            if (!_isPlanetSaved)
                return;

            MainMenuComponent.PlanetName planetName = _mainMenuComponent.GetSelectedPlanet();

            switch (planetName)
            {
                case MainMenuComponent.PlanetName.Saturn when !_dataComponent.InventoryData.isSaturnSaved:
                    _dataComponent.InventoryData.isSaturnSaved = true;
                    _dataComponent.SaveInventoryData();
                    break;
                case MainMenuComponent.PlanetName.Mars when !_dataComponent.InventoryData.isMarsSaved:
                    _dataComponent.InventoryData.isMarsSaved = true;
                    _dataComponent.SaveInventoryData();
                    break;
            }
        }
    }
}