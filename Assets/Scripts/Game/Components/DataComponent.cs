using System.IO;
using UnityEngine;
using Base.Component;
using Game.Datas;

namespace Game.Components
{
    public class DataComponent : MonoBehaviour, IComponent
    {
        private const string _goldDataFileName = "/GoldData.json";
        private const string _planetDataFileName = "/PlanetData.json";
        private const string _superPowerDataFileName = "/SuperPowerData.json";
        private const string _garageDataFileName = "/GarageData.json";
        private const string _inventoryDataFileName = "/InventoryData.json";
        private const string _achievementDataFileName = "/AchievementData.json";

        public GoldData GoldData => _goldData;
        public PlanetData PlanetData => _planetData;
        public SuperPowerData SuperPowerData => _superPowerData;
        public GarageData GarageData => _garageData;
        public InventoryData InventoryData => _inventoryData;
        public AchievementData AchievementData => _achievementData;

        private string _dataPath;

        private GoldData _goldData;
        private PlanetData _planetData;
        private SuperPowerData _superPowerData;
        private GarageData _garageData;
        private InventoryData _inventoryData;
        private AchievementData _achievementData;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            SetDataPath();

            CreateGoldData();
            CreatePlanetData();
            CreateSuperPowerData();
            CreateGarageData();
            CreateInventoryData();
            CreateAchievementData();

            SaveGoldData();
            SavePlanetData();
            SaveSuperPowerData();
            SaveGarageData();
            SaveInventoryData();
            SaveAchievementData();
        }

        public void SaveGoldData()
        {
            SaveData(_goldDataFileName, in _goldData);
        }

        public void SavePlanetData()
        {
            SaveData(_planetDataFileName, in _planetData);
        }

        public void SaveSuperPowerData()
        {
            SaveData(_superPowerDataFileName, in _superPowerData);
        }

        public void SaveGarageData()
        {
            SaveData(_garageDataFileName, in _garageData);
        }

        public void SaveInventoryData()
        {
            SaveData(_inventoryDataFileName, in _inventoryData);
        }

        public void SaveAchievementData()
        {
            SaveData(_achievementDataFileName, in _achievementData);
        }

        private void SetDataPath()
        {
#if UNITY_EDITOR
            _dataPath = Application.dataPath;
#else
            _dataPath = Application.persistentDataPath;
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

        private void CreateGoldData()
        {
            if (!File.Exists(_dataPath + _goldDataFileName))
                _goldData = new GoldData
                {
                    ownedGold = 10000
                };
            else
                LoadData(_goldDataFileName, out _goldData);
        }

        private void CreatePlanetData()
        {
            if (!File.Exists(_dataPath + _planetDataFileName))
                _planetData = new PlanetData();
            else
                LoadData(_planetDataFileName, out _planetData);
        }

        private void CreateSuperPowerData()
        {
            if (!File.Exists(_dataPath + _superPowerDataFileName))
                _superPowerData = new SuperPowerData();
            else
                LoadData(_superPowerDataFileName, out _superPowerData);
        }

        private void CreateGarageData()
        {
            if (!File.Exists(_dataPath + _garageDataFileName))
                _garageData = new GarageData
                {
                    healthLevel = 3,
                    speedLevel = 3,
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
                LoadData(_garageDataFileName, out _garageData);
        }

        private void CreateInventoryData()
        {
            if (!File.Exists(_dataPath + _inventoryDataFileName))
                _inventoryData = new InventoryData();
            else
                LoadData(_inventoryDataFileName, out _inventoryData);
        }

        private void CreateAchievementData()
        {
            if (!File.Exists(_dataPath + _achievementDataFileName))
                _achievementData = new AchievementData();
            else
                LoadData(_achievementDataFileName, out _achievementData);
        }
    }
}