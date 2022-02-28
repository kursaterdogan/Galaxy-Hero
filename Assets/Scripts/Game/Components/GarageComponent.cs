using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class GarageComponent : MonoBehaviour, IComponent, IConstructable, IDestructible
    {
        private UIComponent _uiComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=green>GarageComponent initialized!</color>");
            //TODO GarageState
            //TODO WalletComponent
            //TODO AccountComponent
            //TODO GarageCanvas
            //TODO Add UIComponent, GarageCanvas

            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
        }

        public void OnConstruct()
        {
            throw new System.NotImplementedException();
        }

        public void OnDestruct()
        {
            throw new System.NotImplementedException();
        }
    }
}