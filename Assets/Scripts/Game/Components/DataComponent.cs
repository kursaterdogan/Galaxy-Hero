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

        public CoinData CoinData => _coinData;
        public PlanetData PlanetData => _planetData;
        public SuperPowerData SuperPowerData => _superPowerData;
        public GarageData GarageData => _garageData;

        private string _dataPath;

        private CoinData _coinData;
        private PlanetData _planetData;
        private SuperPowerData _superPowerData;
        private GarageData _garageData;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
            //TODO Handle DataComponent

            SetDataPath();

            CreateCoinData();
            CreatePlanetData();
            CreateSuperPowerData();
            CreateGarageData();

            //TODO Handle Save
            SaveCoinData();
            SavePlanetData();
            SaveSuperPowerData();
            SaveGarageData();
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

        private void SetDataPath()
        {
            _dataPath = Application.dataPath + "/Datas";
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
                    ownedCoin = 1000
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
    }
}