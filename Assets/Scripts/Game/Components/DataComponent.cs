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
        private const string GarageDataFileName = "/GarageData.json";
        
        public CoinData CoinDataObject => _coinDataObject;
        public PlanetData PlanetDataObject => _planetDataObject;
        public GarageData GarageDataObject => _garageDataObject;

        private string _dataPath;

        private CoinData _coinDataObject;
        private PlanetData _planetDataObject;
        private GarageData _garageDataObject;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
            //TODO Handle DataComponent

            SetDataPath();

            CreateCoinData();
            CreatePlanetData();
            CreateGarageData();

            //TODO Handle Save
            SaveCoinData();
            SavePlanetData();
            SaveGarageData();
        }

        public void SaveCoinData()
        {
            SaveData(CoinDataFileName, in _coinDataObject);
        }

        public void SavePlanetData()
        {
            SaveData(PlanetDataFileName, in _planetDataObject);
        }

        public void SaveGarageData()
        {
            SaveData(GarageDataFileName, in _garageDataObject);
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

        private void CreateGarageData()
        {
            if (!File.Exists(_dataPath + GarageDataFileName))
                _garageDataObject = new GarageData
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
                LoadData(GarageDataFileName, out _garageDataObject);
        }

        private void CreateCoinData()
        {
            if (!File.Exists(_dataPath + CoinDataFileName))
                _coinDataObject = new CoinData()
                {
                    ownedCoin = 1000
                };
            else
                LoadData(CoinDataFileName, out _coinDataObject);
        }

        private void CreatePlanetData()
        {
            if (!File.Exists(_dataPath + PlanetDataFileName))
                _planetDataObject = new PlanetData();
            else
                LoadData(PlanetDataFileName, out _planetDataObject);
        }
    }
}