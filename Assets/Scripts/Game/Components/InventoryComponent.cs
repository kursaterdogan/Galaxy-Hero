using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class InventoryComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        public delegate void InventoryCardChangeDelegate();

        public event InventoryCardChangeDelegate OnSaturnCardOpenStart;
        public event InventoryCardChangeDelegate OnSaturnCardShakeStart;
        public event InventoryCardChangeDelegate OnSaturnCardOpenEnd;
        public event InventoryCardChangeDelegate OnSaturnCardShakeEnd;
        public event InventoryCardChangeDelegate OnMarsCardOpenStart;
        public event InventoryCardChangeDelegate OnMarsCardShakeStart;
        public event InventoryCardChangeDelegate OnMarsCardOpenEnd;
        public event InventoryCardChangeDelegate OnMarsCardShakeEnd;

        private DataComponent _dataComponent;

        private bool _isSaturnSaved;
        private bool _isMarsSaved;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");

            _dataComponent = componentContainer.GetComponent("DataComponent") as DataComponent;
        }

        public void OnConstruct()
        {
            SetIsSaturnSaved();
            SetIsMarsSaved();

            StartSaturnCard();
            StartMarsCard();
        }

        public void OnDestruct()
        {
            EndSaturnCard();
            EndMarsCard();
        }

        private void SetIsSaturnSaved()
        {
            _isSaturnSaved = _dataComponent.InventoryData.isSaturnSaved;
        }

        private void SetIsMarsSaved()
        {
            _isMarsSaved = _dataComponent.InventoryData.isMarsSaved;
        }

        private void StartSaturnCard()
        {
            if (_isSaturnSaved)
                OnSaturnCardOpenStart?.Invoke();
            else
                OnSaturnCardShakeStart?.Invoke();
        }

        private void StartMarsCard()
        {
            if (_isMarsSaved)
                OnMarsCardOpenStart?.Invoke();
            else
                OnMarsCardShakeStart?.Invoke();
        }


        private void EndSaturnCard()
        {
            if (_isSaturnSaved)
                OnSaturnCardOpenEnd?.Invoke();
            else
                OnSaturnCardShakeEnd?.Invoke();
        }

        private void EndMarsCard()
        {
            if (_isMarsSaved)
                OnMarsCardOpenEnd?.Invoke();
            else
                OnMarsCardShakeEnd?.Invoke();
        }
    }
}