using System.IO;
using UnityEngine;
using Base.Component;
using Game.Datas;

namespace Game.Components
{
    public class DataComponent : MonoBehaviour, IComponent
    {
        private const string CoinDataFileName = "/CoinData.json";
        private const string PlanetDataFileName = "/PlanetData.json";
        private const string SuperPowerDataFileName = "/SuperPowerData.json";
        private const string GarageDataFileName = "/GarageData.json";
        private const string InventoryDataFileName = "/InventoryData.json";
        private const string AchievementDataFileName = "/AchievementData.json";

        public CoinData CoinData => _coinData;
        public PlanetData PlanetData => _planetData;
        public SuperPowerData SuperPowerData => _superPowerData;
        public GarageData GarageData => _garageData;
        public InventoryData InventoryData => _inventoryData;
        public AchievementData AchievementData => _achievementData;

        private string _dataPath;

        private CoinData _coinData;
        private PlanetData _planetData;
        private SuperPowerData _superPowerData;
        private GarageData _garageData;
        private InventoryData _inventoryData;
        private AchievementData _achievementData;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            SetDataPath();

            CreateCoinData();
            CreatePlanetData();
            CreateSuperPowerData();
            CreateGarageData();
            CreateInventoryData();
            CreateAchievementData();

            SaveCoinData();
            SavePlanetData();
            SaveSuperPowerData();
            SaveGarageData();
            SaveInventoryData();
            SaveAchievementData();
        }

        public void SaveCoinData()
        {
            SaveData(CoinDataFileName, in _coinData);
        }

        public void SavePlanetData()
        {
            SaveData(PlanetDataFileName, in _planetData);
        }

        public void SaveSuperPowerData()
        {
            SaveData(SuperPowerDataFileName, in _superPowerData);
        }

        public void SaveGarageData()
        {
            SaveData(GarageDataFileName, in _garageData);
        }

        public void SaveInventoryData()
        {
            SaveData(InventoryDataFileName, in _inventoryData);
        }

        public void SaveAchievementData()
        {
            SaveData(AchievementDataFileName, in _achievementData);
        }

        private void SetDataPath()
        {
#if UNITY_EDITOR
            _dataPath = Application.dataPath + "/";
#else
            _dataPath = Application.persistentDataPath + "/";
#endif
        }

        private void LoadData<T>(string dataFileName, out T dataObject)
        {
            string content = File.ReadAllText(_dataPath + dataFileName);
            dataObject = JsonUtility.FromJson<T>(content);
        }

        private void SaveData<T>(string dataFileName, in T dataObject)
        {
            string content = JsonUtility.ToJson(dataObject);
            File.WriteAllText(_dataPath + dataFileName, content);
        }

        private void CreateCoinData()
        {
            if (!File.Exists(_dataPath + CoinDataFileName))
                _coinData = new CoinData
                {
                    ownedCoin = 10000
                };
            else
                LoadData(CoinDataFileName, out _coinData);
        }

        private void CreatePlanetData()
        {
            if (!File.Exists(_dataPath + PlanetDataFileName))
                _planetData = new PlanetData();
            else
                LoadData(PlanetDataFileName, out _planetData);
        }

        private void CreateSuperPowerData()
        {
            if (!File.Exists(_dataPath + SuperPowerDataFileName))
                _superPowerData = new SuperPowerData();
            else
                LoadData(SuperPowerDataFileName, out _superPowerData);
        }

        private void CreateGarageData()
        {
            if (!File.Exists(_dataPath + GarageDataFileName))
                _garageData = new GarageData
                {
                    healthLevel = 1,
                    speedLevel = 1,
                    cannonLevel = 1,
                    powerLevel = 1,
                    fireRateLevel = 1,
                    scoreMultiplierLevel = 1,
                    goldMultiplierLevel = 1,
                    shildeoLevel = 1,
                    ghosteoLevel = 1,
                    bombeoLevel = 1
                };
            else
                LoadData(GarageDataFileName, out _garageData);
        }

        private void CreateInventoryData()
        {
            if (!File.Exists(_dataPath + InventoryDataFileName))
                _inventoryData = new InventoryData();
            else
                LoadData(InventoryDataFileName, out _inventoryData);
        }

        private void CreateAchievementData()
        {
            if (!File.Exists(_dataPath + AchievementDataFileName))
                _achievementData = new AchievementData();
            else
                LoadData(AchievementDataFileName, out _achievementData);
        }
    }
}