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
    }
}