using System.IO;
using UnityEngine;
using Base.Component;
using Game.Datas;

namespace Game.Components
{
    public class DataComponent : MonoBehaviour, IComponent
    {
        public GarageData GarageDataObject => _garageDataObject;

        private string _dataPath;

        private string _garageDataFileName = "/GarageData.json";
        private GarageData _garageDataObject;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
            //TODO Handle DataComponent

            SetDataPath();
            CreateGarageData();

            //TODO Create DefaultData
        }

        public void SaveGarageData()
        {
            SaveData(_garageDataFileName, in _garageDataObject);
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
            if (!File.Exists(_dataPath + _garageDataFileName))
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
                LoadData(_garageDataFileName, out _garageDataObject);
        }
    }
}